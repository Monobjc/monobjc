## =======================================
## Monobjc.DiscRecordingUI Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.DiscRecordingUI
REFERENCES=$(DEST_DIR)/Monobjc.dll $(DEST_DIR)/Monobjc.Foundation.dll $(DEST_DIR)/Monobjc.AppKit.dll $(DEST_DIR)/Monobjc.DiscRecording.dll
HAS_RESX=0
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/DiscRecordingUI_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/DiscRecordingUI_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/DiscRecordingUI_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
