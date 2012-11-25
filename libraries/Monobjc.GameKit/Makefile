## =======================================
## Monobjc.GameKit Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.GameKit
REFERENCES=-r:"$(DEST_DIR)/Monobjc.dll" -r:"$(DEST_DIR)/Monobjc.Foundation.dll" -r:"$(DEST_DIR)/Monobjc.AppKit.dll"
HAS_RESX=0
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/GameKit_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/GameKit_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/GameKit_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/GameKit_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
