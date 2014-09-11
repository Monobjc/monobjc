## =======================================
## Monobjc.SpriteKit Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.SpriteKit
REFERENCES=$(DEST_DIR)/Monobjc.dll $(DEST_DIR)/Monobjc.Foundation.dll $(DEST_DIR)/Monobjc.AppKit.dll $(DEST_DIR)/Monobjc.CoreMedia.dll $(DEST_DIR)/Monobjc.AVFoundation.dll
HAS_RESX=0
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SpriteKit_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SpriteKit_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SpriteKit_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SpriteKit_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
