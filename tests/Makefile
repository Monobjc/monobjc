## =======================================
## Tests Makefile
## =======================================

include ../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

FOUNDATION_TESTS_10_6= \
	Monobjc.Tests \
	Monobjc.Foundation.Tests \
	Monobjc.Collaboration.Tests \

#	Monobjc.CoreMIDI.Tests \
#	Monobjc.DiscRecording.Tests \
#	Monobjc.OpenGL.Tests \
#	Monobjc.ScriptingBridge.Tests \
#	Monobjc.Security.Tests \
#	Monobjc.SecurityFoundation.Tests \
#	Monobjc.Social.Tests \
#	Monobjc.CoreWLAN.Tests

FOUNDATION_TESTS_10_7= \
	$(FOUNDATION_TESTS_10_6) \
#	Monobjc.StoreKit.Tests

FOUNDATION_TESTS_10_8= \
	$(FOUNDATION_TESTS_10_7) \
	Monobjc.Accounts.Tests

UI_TESTS_10_6= \
	Monobjc.AppKit.Tests \
	Monobjc.AddressBook.Tests \

#	Monobjc.CoreLocation.Tests \
#	Monobjc.CoreMedia.Tests \
#	Monobjc.DiscRecordingUI.Tests \
#	Monobjc.EventKit.Tests \
#	Monobjc.InputMethodKit.Tests \
#	Monobjc.InstantMessage.Tests \
#	Monobjc.QTKit.Tests \
#	Monobjc.Quartz.Tests \
#	Monobjc.SecurityInterface.Tests \
#	Monobjc.WebKit.Tests \
#	Monobjc.AVFoundation.Tests

UI_TESTS_10_7= \
	$(UI_TESTS_10_6)

UI_TESTS_10_8= \
	$(UI_TESTS_10_7) \
	
#	Monobjc.EventKit.Tests \
#	Monobjc.GameKit.Tests \
#	Monobjc.GLKit.Tests \
#	Monobjc.SceneKit.Tests \

THIRDPARTY_TESTS= \
	Monobjc.CorePlot.Tests \
	
#	Monobjc.Growl.Tests \
#	Monobjc.Sparkle.Tests

TESTS_10_6=$(FOUNDATION_TESTS_10_6) $(UI_TESTS_10_6) $(THIRDPARTY_TESTS)
TESTS_10_7=$(FOUNDATION_TESTS_10_7) $(UI_TESTS_10_7) $(THIRDPARTY_TESTS)
TESTS_10_8=$(FOUNDATION_TESTS_10_8) $(UI_TESTS_10_8) $(THIRDPARTY_TESTS)

DEFINES_COMMON=DEBUG,TESTING

# ----------------------------------------
# Targets
# ----------------------------------------

all:
	if [ $(BUILD_FOR_OSX_10_6) = 1 ]; then \
		for i in $(TESTS_10_6); do \
			echo "# ----------------------------------------"; \
			echo "# Building $$i for 10.6"; \
			echo "# ----------------------------------------"; \
			(cd $$i; make DEST_DIR="$(DIST_DIR)/10.6" DEFINES="$(DEFINES_COMMON),MACOSX_10_6" all); \
		done; \
	fi
	
	if [ $(BUILD_FOR_OSX_10_7) = 1 ]; then \
		for i in $(TESTS_10_7); do \
			echo "# ----------------------------------------"; \
			echo "# Building $$i for 10.7"; \
			echo "# ----------------------------------------"; \
			(cd $$i; make DEST_DIR="$(DIST_DIR)/10.7" DEFINES="$(DEFINES_COMMON),MACOSX_10_6,MACOSX_10_7" all); \
		done; \
	fi

	if [ $(BUILD_FOR_OSX_10_8) = 1 ]; then \
		for i in $(TESTS_10_8); do \
			echo "# ----------------------------------------"; \
			echo "# Building $$i for 10.8"; \
			echo "# ----------------------------------------"; \
			(cd $$i; make DEST_DIR="$(DIST_DIR)/10.8" DEFINES="$(DEFINES_COMMON),MACOSX_10_6,MACOSX_10_7,MACOSX_10_8" all); \
		done; \
	fi

clean:
	if [ $(BUILD_FOR_OSX_10_6) = 1 ]; then \
		for i in $(TESTS_10_6); do (cd $$i; make clean); done \
	fi
	
	if [ $(BUILD_FOR_OSX_10_7) = 1 ]; then \
		for i in $(TESTS_10_7); do (cd $$i; make clean); done \
	fi
	
	if [ $(BUILD_FOR_OSX_10_8) = 1 ]; then \
		for i in $(TESTS_10_8); do (cd $$i; make clean); done \
	fi
