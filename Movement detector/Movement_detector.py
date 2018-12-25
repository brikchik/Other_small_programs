# -*- encoding: utf-8 -*-
# usage:
# no arguments to capture frames from camera,
# filename to detect movement in it
#
USECAMERA=True
DIVIDER=10 #moving part of the frame
SKIP=5 #for better performance we may skip frames
FILENAME='input.mp4' #default filename
# get argument
import sys
if len(sys.argv)>1:
    USECAMERA=False
    FILENAME=sys.argv[1]

import numpy as np
import cv2
import os
def stack(frame, fgmask): #unite black-and-white and rgb images
    mask=frame.copy()
    if SHOWORIGINALFOREGROUND:
        mask[:,:,0]=fgmask
        mask[:,:,1]=fgmask
        mask[:,:,2]=fgmask
    else:
        mask[:,:,0]=mask[:,:,0]&fgmask
        mask[:,:,1]=mask[:,:,1]&fgmask
        mask[:,:,2]=mask[:,:,2]&fgmask
    result=np.hstack((frame, mask))
    return result
counter=0 #frame number
alarmCounter=0 #movement length
try: os.mkdir('captured')
except:
    for f in os.listdir('captured'):
        os.remove('captured/'+f)
log=open('captured/log.txt', 'w')
if USECAMERA:
    vidcap = cv2.VideoCapture(0)
    fgbg = cv2.createBackgroundSubtractorMOG2() #works better in some cases
else:
    vidcap=cv2.VideoCapture(FILENAME)
    fgbg = cv2.bgsegm.createBackgroundSubtractorMOG()
FPS = vidcap.get(cv2.CAP_PROP_FPS)
while(1):
    for i in range(1, SKIP+2): ret, frame = vidcap.read()
    if not ret: break
    frame=cv2.resize(frame,(640,480))
    counter+=(SKIP+1)
    fgmask = fgbg.apply(frame, learningRate=0.99)
    if fgmask.mean()>255/DIVIDER:
        if alarmCounter==0:
            print (('ALARM'+ '  Frame:'+str(counter)+'   Time: '+"%.2f"+'c')% (counter/FPS))
            log.write(('ALARM'+ '  Frame:'+str(counter)+'   Time: '+"%.2f"+'c\n')% (counter/FPS))
            cv2.imwrite('captured/'+("%.2f"+'s')% (counter/FPS)+'.jpg', stack(frame, fgmask))
            print ('Screenshot saved: '+'captured/'+("%.2f"+'s')% (counter/FPS)+'.jpg')
            log.write('Screenshot saved: '+'captured/'+("%.2f"+'s')% (counter/FPS)+'.jpg\n')
        alarmCounter+=((SKIP+1)/FPS)
        cv2.putText(frame, "TPEBOI'A", (0,100),cv2.FONT_HERSHEY_SIMPLEX,2,(0,0,255),2,cv2.LINE_AA)
        print (str(int(fgmask.sum()/fgmask.shape[0]/fgmask.shape[1]))+'%')
    else:
        if alarmCounter>0:
            print (('Movement length: '+"%.2f"+' c') % alarmCounter)
            print (('End of movement'+ '  Frame:'+str(counter)+'   Time: '+"%.2f"+'с')% (counter/FPS))
            print()
            log.write(('Movement length: '+"%.2f"+' c\n') % alarmCounter)
            log.write(('End of movement'+ '  Frame:'+str(counter)+'   Time: '+"%.2f"+'с\n')% (counter/FPS))
            log.write('\n')
            log.flush()
            alarmCounter=0
    #
    # this part tries to find moving objects. works separately.
    #
    borderSize = frame.shape[0]*frame.shape[1]//100 #min object size
    maxBorderSize = frame.shape[0]*frame.shape[1]//4 #max object size
    _,contours,_=cv2.findContours(fgmask, 1, 2)
    for cnt in contours:
        if cv2.contourArea(cnt)>borderSize and cv2.contourArea(cnt)<maxBorderSize:
            x,y,w,h=cv2.boundingRect(cnt)
            cx=x+w//4*3-w//5*2
            cy=y+h//2
            cv2.drawContours(frame, [cnt], 0, (200,200,200),1)
            cv2.rectangle(frame, (x,y), (x+w, y+h), (0,255,0), 2)
            cv2.putText(frame, "ALARM", (cx-w//3,cy),cv2.FONT_HERSHEY_SIMPLEX,2,(0,255,0),2,cv2.LINE_AA)
    cv2.imshow('result',stack(frame,fgmask)) #show the result
    k = cv2.waitKey(30) & 0xff
    if k == 27: break
vidcap.release()
log.close()
cv2.destroyAllWindows()