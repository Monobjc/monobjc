## =======================================
## Monobjc.GLKit Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.GLKit
REFERENCES=$(DEST_DIR)/Monobjc.dll $(DEST_DIR)/Monobjc.Foundation.dll $(DEST_DIR)/Monobjc.AppKit.dll $(DEST_DIR)/Monobjc.OpenGL.dll
HAS_RESX=0
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/GLKit_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/GLKit_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/GLKit_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/GLKit_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/GLKit_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
