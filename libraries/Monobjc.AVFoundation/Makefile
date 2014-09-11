## =======================================
## Monobjc.AVFoundation Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.AVFoundation
REFERENCES=$(DEST_DIR)/Monobjc.dll $(DEST_DIR)/Monobjc.Foundation.dll $(DEST_DIR)/Monobjc.AppKit.dll $(DEST_DIR)/Monobjc.CoreMedia.dll
HAS_RESX=0
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/AVFoundation_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/AVFoundation_Extensions/*.cs) \
    $(wildcard $(LIBRARIES_DIR)/$(NAME)/AVFoundation_P/*.cs) \
    $(wildcard $(LIBRARIES_DIR)/$(NAME)/AVFoundation_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/AVFoundation_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
