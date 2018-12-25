from MarkerDetector import *
md=MarkerDetector()
# constans are here for easy configuration
md.minSize=2000
md.maxSize=100000
md.minWidth=50
md.minHeight=50
md.BINARIZATION=-1
md.SQUARE_CRITERIA=90
md.AVERAGE_COLOR_THRESHOLD=150
md.exclude=[]
md.processImage("source.jpg")
