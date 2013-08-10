## =======================================
## Monobjc.AppKit Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.AppKit
REFERENCES=$(DEST_DIR)/Monobjc.dll $(DEST_DIR)/Monobjc.Foundation.dll
HAS_RESX=1
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/AppKit_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/AppKit_E/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/AppKit_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/AppKit_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/AppKit_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/AppKit_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/QuartzCore_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/QuartzCore_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/QuartzCore_Functions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/QuartzCore_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/QuartzCore_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/QuartzCore_T/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
