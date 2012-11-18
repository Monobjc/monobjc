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
	Monobjc.DiscRecording \
	Monobjc.OpenGL \
	Monobjc.ScriptingBridge \
	Monobjc.Security \
	Monobjc.SecurityFoundation \
	Monobjc.Social \
	Monobjc.StoreKit \
	Monobjc.CoreWLAN

UI_LIBRARIES= \
	Monobjc.AppKit \
	Monobjc.AddressBook \
	Monobjc.CoreLocation \
	Monobjc.CoreMedia \
	Monobjc.DiscRecordingUI \
	Monobjc.EventKit \
	Monobjc.GameKit \
	Monobjc.GLKit \
	Monobjc.InputMethodKit \
	Monobjc.InstantMessage \
	Monobjc.QTKit \
	Monobjc.Quartz \
	Monobjc.SceneKit \
	Monobjc.SecurityInterface \
	Monobjc.WebKit \
	Monobjc.AVFoundation

THIRDPARTY_LIBRARIES= \
	Monobjc.CorePlot \
	Monobjc.Growl \
	Monobjc.Sparkle

LIBRARIES = $(FOUNDATION_LIBRARIES) $(UI_LIBRARIES) $(THIRDPARTY_LIBRARIES)

DEFINES_COMMON=DUMMY
ifeq ($(DEBUG_MODE),true)
	DEFINES_COMMON+=,DEBUG
endif
ifeq ($(TESTING_MODE),true)
	DEFINES_COMMON+=,TESTING
endif

DOC_XML_DIR=$(DIST_DIR)/10.8
DOC_XML_FILES=$(wildcard $(DOC_XML_DIR)/Monobjc*.xml)
DOC_XML_NAMES=$(basename $(notdir $(DOC_XML_FILES)))
DOC_BUILD_DIR=$(BUILD_DIR)/monodoc
DOC_DIST_DIR=$(DIST_DIR)/monodoc

# ----------------------------------------
# Targets
# ----------------------------------------

all:
	(cd ../tools; make generate-wrappers);

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
	$(RMRF) $(DOC_BUILD_DIR)
	$(RMRF) $(DOC_DIST_DIR)

generate-doc:
	$(MKDIR) $(DOC_BUILD_DIR)
	$(MKDIR) $(DOC_DIST_DIR)
	
	# First pass
	for i in $(DOC_XML_NAMES); do \
		($(MONODOCER) -importslashdoc:$(DOC_XML_DIR)/$$i.xml -assembly:$(DOC_XML_DIR)/$$i.dll -path:$(DOC_BUILD_DIR)/$$i); \
	done;
	
	# Second pass
	$(MDASSEMBLER) -o $(DOC_DIST_DIR)/Monobjc $(addprefix $(DOC_BUILD_DIR)/,$(DOC_XML_NAMES))

	# Third pass
	$(CPC) $(LIBRARIES_DIR)/Monobjc.source $(DOC_DIST_DIR)
