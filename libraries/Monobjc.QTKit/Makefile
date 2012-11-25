## =======================================
## Monobjc.QTKit Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.QTKit
REFERENCES=-r:"$(DEST_DIR)/Monobjc.dll" -r:"$(DEST_DIR)/Monobjc.Foundation.dll" -r:"$(DEST_DIR)/Monobjc.AppKit.dll"
HAS_RESX=0
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/QTKit_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/QTKit_E/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/QTKit_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/QTKit_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/QTKit_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
