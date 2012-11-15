## =======================================
## Libraries Makefile
## =======================================

include ../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

FOUNDATION_LIBRARIES= \
	Monobjc \
	Monobjc.Foundation \
	Monobjc.Accounts \
	Monobjc.Collaboration \
	Monobjc.CoreMIDI \
	Monobjc.CoreWLAN \
	Monobjc.DiscRecording \
	Monobjc.OpenGL \
	Monobjc.ScriptingBridge \
	Monobjc.Security \
	Monobjc.SecurityFoundation \
	Monobjc.StoreKit
	
UI_LIBRARIES= \
	Monobjc.AppKit \
	Monobjc.AddressBook \
	Monobjc.AVFoundation \
	Monobjc.CoreLocation \
	Monobjc.CoreMedia \
	Monobjc.CorePlot \
	Monobjc.DiscRecordingUI \
	Monobjc.EventKit \
	Monobjc.GameKit \
	Monobjc.GLKit \
	Monobjc.Growl \
	Monobjc.InputMethodKit \
	Monobjc.InstantMessage \
	Monobjc.QTKit \
	Monobjc.Quartz \
	Monobjc.SceneKit \
	Monobjc.SecurityInterface \
	Monobjc.Social \
	Monobjc.Sparkle \
	Monobjc.WebKit

LIBRARIES = $(FOUNDATION_LIBRARIES)
#$(UI_LIBRARIES) 

DEFINES_COMMON=DUMMY
ifeq ($(DEBUG_MODE),true)
	DEFINES_COMMON+=,DEBUG
endif
ifeq ($(TESTING_MODE),true)
	DEFINES_COMMON+=,TESTING
endif

# ----------------------------------------
# Targets
# ----------------------------------------

all:
	if [ $(BUILD_FOR_OSX_10_6) = 1 ]; then \
		for i in $(LIBRARIES); do \
			echo "# ----------------------------------------"; \
			echo "# Building $$i for 10.6"; \
			echo "# ----------------------------------------"; \
			(cd $$i; make DEST_DIR="$(DIST_DIR)/10.6" DEFINES="$(DEFINES_COMMON),MACOSX_10_6" all); \
		done; \
	fi
	if [ $(BUILD_FOR_OSX_10_7) = 1 ]; then \
		for i in $(LIBRARIES); do \
			echo "# ----------------------------------------"; \
			echo "# Building $$i for 10.7"; \
			echo "# ----------------------------------------"; \
			(cd $$i; make DEST_DIR="$(DIST_DIR)/10.7" DEFINES="$(DEFINES_COMMON),MACOSX_10_6,MACOSX_10_7" all); \
		done; \
	fi
	if [ $(BUILD_FOR_OSX_10_8) = 1 ]; then \
		for i in $(LIBRARIES); do \
			echo "# ----------------------------------------"; \
			echo "# Building $$i for 10.8"; \
			echo "# ----------------------------------------"; \
			(cd $$i; make DEST_DIR="$(DIST_DIR)/10.8" DEFINES="$(DEFINES_COMMON),MACOSX_10_6,MACOSX_10_7,MACOSX_10_8" all); \
		done; \
	fi

clean:
	for i in $(LIBRARIES); do (cd $$i; make clean); done
