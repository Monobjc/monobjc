## =======================================
## Monobjc.SceneKit Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.SceneKit
REFERENCES=-r:"$(DEST_DIR)/Monobjc.dll" -r:"$(DEST_DIR)/Monobjc.Foundation.dll" -r:"$(DEST_DIR)/Monobjc.AppKit.dll"
HAS_RESX=0
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SceneKit_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SceneKit_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SceneKit_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SceneKit_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
