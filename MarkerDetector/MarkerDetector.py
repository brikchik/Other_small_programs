# -*- encoding: utf-8 -*-
# usage:
# set parameters, set source image, run
# example is given
import cv2
import numpy as np

class MarkerDetector:
    # marker size and dimensions:
    minSize=3000
    maxSize=30000
    minWidth=70
    minHeight=70
    # custom binarization border; set to -1 to disable:
    BINARIZATION=-1 
    # max difference between square and marker shape:
    SQUARE_CRITERIA=90 # percent of contour area in box area; close areas -> contour is almost square
    # making sure that marker has light center and dark borders:
    AVERAGE_COLOR_THRESHOLD=0
    # filter false positives
    exclude=[]

    def MarkerDetector():
        pass
    def prepareImage(self,img):
        # equalize hist (make markers human visible for bad images)
        img_yuv = cv2.cvtColor(img, cv2.COLOR_BGR2YUV)
        img_yuv[:,:,0] = cv2.equalizeHist(img_yuv[:,:,0])
        img = cv2.cvtColor(img_yuv, cv2.COLOR_YUV2BGR)
        gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY) # to grayscale
        thresh = cv2.threshold(gray, 0, 255, cv2.THRESH_BINARY_INV|cv2.THRESH_OTSU)[1]
        # custom binarization code (just because)
        if self.BINARIZATION!=-1:
            gray[gray>self.BINARIZATION]=255
            gray[gray<self.BINARIZATION]=0
            thresh=gray # use custom binarization if set
        gray=cv2.dilate(gray,(5,5)) # try to make contours convex
        resgray=np.dstack([thresh.astype(np.uint8)] * 3).copy(order='C')
        res=np.hstack((img,resgray))
        cv2.imshow("gray",cv2.resize(res,(1000,700)))
        # show source and prepared images
        return thresh
    def findMarkerCandidates(self, thresh):
        _,contours,h = cv2.findContours(thresh,1,2) # search for contours
        list=[]
        for cnt in contours:
            x,y,w,h=cv2.boundingRect(cnt)
            if cv2.contourArea(cnt)>self.minSize and cv2.contourArea(cnt)<self.maxSize and w>self.minWidth and h>self.minHeight and abs(w-h)<h:
                # check size
                eps=0.04 * cv2.arcLength(cnt, True)
                approxCurve = cv2.approxPolyDP(cnt,eps , True)
                if len(approxCurve)>=4 and cv2.isContourConvex(approxCurve): # is contour a convex square?
                    mincnt=np.int0(cv2.boxPoints(cv2.minAreaRect(cnt)))
                    boxArea=cv2.contourArea(mincnt)
                    cntArea=cv2.contourArea(cnt)
                    if abs(boxArea-cntArea) / boxArea < self.SQUARE_CRITERIA:
                        # check if contour is close to square box
                        if np.average(thresh[y:y+h, x:x+w])>self.AVERAGE_COLOR_THRESHOLD: #последняя проверка, внутри маркера должно быть много белого
                            # check if marker cencer is bright
                            list.append(cnt)
        # remove close contours
        badCandidates=[]
        def outerXY(cnt, cnt2): #returns outer contour
            x,y,w,h=cv2.boundingRect(cnt)
            x2,y2,_,_=cv2.boundingRect(cnt2)
            if x!=x2 and y!=y2 and x2 in range(x, x+w) and y2 in range(y, y+h):
                if cv2.contourArea(cnt)>cv2.contourArea(cnt2):
                    return (x,y)
                else:
                    return (x2,y2)
            else:
                return -1
        badCoords=[]
        for cnt in list:
            for cnt2 in list:
                XY=outerXY(cnt,cnt2)
                if XY!=-1 and not XY in badCoords:
                    badCoords.append(XY)
        markerCandidates=[]
        for cnt in list:
            x,y,_,_=cv2.boundingRect(cnt)
            isGood=True
            for xy in badCoords:
                if xy[0]==x and xy[1]==y:
                    isGood=False
            if isGood:
                markerCandidates.append(cnt)
        # no excessive contours left
        for i in range(len(self.exclude)):
            del markerCandidates[self.exclude[i]-1]
        return markerCandidates
    def saveMarkers(self, img, markerCandidates): # marks markers, writes coords and image to file
        text=open("result.txt","w+")
        text.write("X    Y    \n")
        cv2.drawContours(img, markerCandidates, -1, (0,0,255), 10)
        for i, cnt in enumerate(markerCandidates):
            x,y,w,h=cv2.boundingRect(cnt)
            text.write(str(x)+"    "+str(y)+"\n")
            cv2.putText(img,str(i+1),(x-w//2,y+h//2),cv2.FONT_HERSHEY_SIMPLEX,2,(0,0,0),8)
            cv2.putText(img,str(x)+","+str(y),(x,y-10),cv2.FONT_HERSHEY_SIMPLEX,2,(255,0,0),4)
            cv2.rectangle(img,(x-2,y-2),(x+w+1,y+h+1),(0,255,255),3)
            cv2.line(img,(x-2,y-2),(x+w+1,y+h+1),(0,255,0),3)
            cv2.line(img,(x+w+1,y-2),(x-2,y+h+1),(0,255,0),3)
            cv2.putText(img,str(w)+"x"+str(h),(x,y+h+50),cv2.FONT_HERSHEY_SIMPLEX,2,(255,0,0),4)
        cv2.imshow("im",cv2.resize(img,(600,700)))
        cv2.imwrite("result.png", img)
        text.close()
    def getTransformations(self, thresh, candidates): #rotates contours if possible
        # returns 150x150 images ready for analysis
        def sortPoints(rect):
            a,b,c,d=rect
            p1=p2=p3=p4=a
            sortedArr=[]
            leftx=min(a[0],b[0],c[0],d[0])
            topy=min(a[1],b[1],c[1],d[1])
            a[0]-=leftx
            b[0]-=leftx
            c[0]-=leftx
            d[0]-=leftx
            a[1]-=topy
            b[1]-=topy
            c[1]-=topy
            d[1]-=topy
            cx=(a[0]+b[0]+c[0]+d[0])//4
            cy=(a[1]+b[1]+c[1]+d[1])//4
            for a in rect:
                if a[0]<=cx and a[1]<=cy: p1=a
                if a[0]>cx and a[1]<=cy: p2=a
                if a[0]<=cx and a[1]>cy: p3=a
                if a[0]>cx and a[1]>cy: p4=a
            sortedArr.append(p1)
            sortedArr.append(p2)
            sortedArr.append(p3)
            sortedArr.append(p4)
            return sortedArr
        markerPictures=[]
        for i,cnt in enumerate(candidates):
            minRect=np.int0(cv2.boxPoints(cv2.minAreaRect(cnt)))
            points=sortPoints(minRect)
            pts1 = np.float32(points)
            pts2 = np.float32([[0,0],[150,0],[0,150],[150,150]])
            y,x,h,w=cv2.boundingRect(cnt)
            piece=thresh[x:x+w,y:y+h]
            M = cv2.getPerspectiveTransform(pts1,pts2)
            dst = cv2.warpPerspective(piece,M,(150,150))
            markerPictures.append(dst)
            if i==0: res=dst
            else: res=np.hstack((res,dst))
        if res.any(): cv2.imshow("Markers",cv2.resize(res,(100*len(markerPictures),100)))
        return markerPictures
    def processImage(self, path):
        image = cv2.imread(path)
        thresh=255-self.prepareImage(image)#инвертируем, так удобнее
        candidates=self.findMarkerCandidates(thresh)
        self.saveMarkers(image, candidates)
        MARKERS=self.getTransformations(thresh, candidates)
        # you may draw something inside markers and analyze it using 150x150 MARKERS array images
