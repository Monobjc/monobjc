## =======================================
## Tests Makefile
## =======================================

include ../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

DIRS_10_6= \
	Monobjc.Tests \
	Monobjc.Foundation.Tests \
	Monobjc.CoreMIDI.Tests \
	Monobjc.CoreWLAN.Tests \
	Monobjc.DiscRecording.Tests \
	Monobjc.OpenGL.Tests \
	Monobjc.ScriptingBridge.Tests \
	Monobjc.Security.Tests \
	Monobjc.SecurityFoundation.Tests \
	\
	Monobjc.AppKit.Tests \
	Monobjc.AddressBook.Tests \
	Monobjc.Collaboration.Tests \
	Monobjc.CoreLocation.Tests \
	Monobjc.DiscRecordingUI.Tests \
	Monobjc.InputMethodKit.Tests \
	Monobjc.InstantMessage.Tests \
	Monobjc.QTKit.Tests \
	Monobjc.Quartz.Tests \
	Monobjc.SecurityInterface.Tests \
	Monobjc.WebKit.Tests \
	\
	Monobjc.CorePlot.Tests \
	Monobjc.Growl.Tests \
	Monobjc.Sparkle.Tests \

DIRS_10_7= \
	$(DIRS_10_6) \
	\
	Monobjc.CoreMedia.Tests \
	Monobjc.AVFoundation.Tests \
	Monobjc.StoreKit.Tests \

DIRS_10_8= \
	$(DIRS_10_7) \
	\
	Monobjc.Accounts.Tests \
	\
	Monobjc.EventKit.Tests \
	Monobjc.Social.Tests \
	Monobjc.GameKit.Tests \
	Monobjc.GLKit.Tests \
	Monobjc.SceneKit.Tests \

ifeq ($(BUILD_FOR_OSX_10_6),1)
	DIRS_10_6_ALL=$(DIRS_10_6:%=%-10_6-all)
	DIRS_10_6_CLEAN=$(DIRS_10_6:%=%-10_6-clean)
endif

ifeq ($(BUILD_FOR_OSX_10_7),1)
	DIRS_10_7_ALL=$(DIRS_10_7:%=%-10_7-all)
	DIRS_10_7_CLEAN=$(DIRS_10_7:%=%-10_7-clean)
endif

ifeq ($(BUILD_FOR_OSX_10_8),1)
	DIRS_10_8_ALL=$(DIRS_10_8:%=%-10_8-all)
	DIRS_10_8_CLEAN=$(DIRS_10_8:%=%-10_8-clean)
endif

DEFINES_COMMON=DUMMY
ifeq ($(DEBUG_MODE),true)
	DEFINES_COMMON+=,DEBUG
endif
ifeq ($(TESTING_MODE),true)
	DEFINES_COMMON+=,TESTING
endif

DEFINES_10_6=$(DEFINES_COMMON),MACOSX_10_6
DEFINES_10_7=$(DEFINES_10_6),MACOSX_10_7
DEFINES_10_8=$(DEFINES_10_7),MACOSX_10_8

# ----------------------------------------
# Targets
# ----------------------------------------

all: $(DIRS_10_6_ALL) $(DIRS_10_7_ALL) $(DIRS_10_8_ALL)
	$(CPC) $(EXTERNAL_DIR)/nunit.framework.dll $(DIST_DIR)/10.6
	$(CPC) $(EXTERNAL_DIR)/nunit.framework.dll $(DIST_DIR)/10.7
	$(CPC) $(EXTERNAL_DIR)/nunit.framework.dll $(DIST_DIR)/10.8
	$(CPC) $(TESTS_DIR)/nunit-* $(DIST_DIR)

clean: $(DIRS_10_6_CLEAN) $(DIRS_10_7_CLEAN) $(DIRS_10_8_CLEAN)

#
# Composite target have the following form: <LIBRARY>-<VERSION>-<ACTION>
#
# $(word 1,$(subst -, ,$@)) returns the <LIBRARY> (i.e. Monobjc)
# $(word 2,$(subst -, ,$@)) returns the <VERSION> (i.e. 10_8)
#
$(DIRS_10_6_ALL) $(DIRS_10_7_ALL) $(DIRS_10_8_ALL):
	$(MAKE) -C $(word 1,$(subst -, ,$@)) DEST_DIR="$(DIST_DIR)/$(subst _,.,$(word 2,$(subst -, ,$@)))" DEFINES="$(DEFINES_$(word 2,$(subst -, ,$@)))" all

$(DIRS_10_6_CLEAN) $(DIRS_10_7_CLEAN) $(DIRS_10_8_CLEAN):
	$(MAKE) -C $(word 1,$(subst -, ,$@)) clean

# ----------------------------------------
# Phony Targets
# ----------------------------------------

.PHONY: subdirs $(DIRS_10_6_ALL)
.PHONY: subdirs $(DIRS_10_7_ALL)
.PHONY: subdirs $(DIRS_10_8_ALL)
.PHONY: subdirs $(DIRS_10_6_CLEAN)
.PHONY: subdirs $(DIRS_10_7_CLEAN)
.PHONY: subdirs $(DIRS_10_8_CLEAN)

.PHONY: \
	all \
	clean
