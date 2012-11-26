## =======================================
## DIRS Makefile
## =======================================

include ../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

DIRS_10_6= \
	Monobjc \
	Monobjc.Foundation \
	Monobjc.CoreMIDI \
	Monobjc.DiscRecording \
	Monobjc.OpenGL \
	Monobjc.ScriptingBridge \
	Monobjc.Security \
	Monobjc.SecurityFoundation \
	Monobjc.CoreWLAN \
	\
	Monobjc.AppKit \
	Monobjc.AddressBook \
	Monobjc.Collaboration \
	Monobjc.CoreLocation \
	Monobjc.CoreMedia \
	Monobjc.DiscRecordingUI \
	Monobjc.InputMethodKit \
	Monobjc.InstantMessage \
	Monobjc.QTKit \
	Monobjc.Quartz \
	Monobjc.SecurityInterface \
	Monobjc.WebKit \
	Monobjc.AVFoundation \
	\
	Monobjc.CorePlot \
	Monobjc.Growl \
	Monobjc.Sparkle

DIRS_10_7= \
	$(DIRS_10_6) \
	Monobjc.StoreKit

DIRS_10_8= \
	$(DIRS_10_7) \
	Monobjc.Accounts \
	Monobjc.Social \
	\
	Monobjc.EventKit \
	Monobjc.GameKit \
	Monobjc.GLKit \
	Monobjc.SceneKit

ifeq ($(BUILD_FOR_OSX_10_6),1)
	DIRS_10_6_ALL=$(DIRS_10_6:%=%-10_6-all)
	DIRS_10_6_CLEAN=$(DIRS_10_6:%=%-10-6-clean)
endif

ifeq ($(BUILD_FOR_OSX_10_7),1)
	DIRS_10_7_ALL=$(DIRS_10_7:%=%-10_7-all)
	DIRS_10_7_CLEAN=$(DIRS_10_7:%=%-10-7-clean)
endif

ifeq ($(BUILD_FOR_OSX_10_8),1)
	DIRS_10_8_ALL=$(DIRS_10_8:%=%-10_8-all)
	DIRS_10_8_CLEAN=$(DIRS_10_8:%=%-10-8-clean)
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

DOC_XML_DIR=$(DIST_DIR)/10.8
DOC_XML_FILES=$(wildcard $(DOC_XML_DIR)/Monobjc*.xml)
DOC_XML_NAMES=$(basename $(notdir $(DOC_XML_FILES)))
DOC_BUILD_DIR=$(BUILD_DIR)/monodoc
DOC_DIST_DIR=$(DIST_DIR)/monodoc

# ----------------------------------------
# Targets
# ----------------------------------------

all: generate-wrappers $(DIRS_10_6_ALL) $(DIRS_10_7_ALL) $(DIRS_10_8_ALL)

generate-wrappers:
	$(MAKE) -C $(TOOLS_DIR) generate-wrappers

clean: $(DIRS_10_6_CLEAN) $(DIRS_10_7_CLEAN) $(DIRS_10_8_CLEAN)
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
	$(CPC) $(DIRS_DIR)/Monobjc.source $(DOC_DIST_DIR)

#
# Composite target have the following form: <LIBRARY>-<VERSION>-<ACTION>
#
# $(word 1,$(subst -, ,$@)) returns the <LIBRARY> (i.e. Monobjc)
# $(word 2,$(subst -, ,$@)) returns the <VERSION> (i.e. 10_8)
# $(word 3,$(subst -, ,$@)) returns the <ACTION> (i.e. all)
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
	generate-wrappers \
	clean \
	generate-doc
