## =======================================
## Monobjc.WebKit Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.WebKit
REFERENCES=-r:"$(DEST_DIR)/Monobjc.dll" -r:"$(DEST_DIR)/Monobjc.Foundation.dll" -r:"$(DEST_DIR)/Monobjc.AppKit.dll"
HAS_RESX=0
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/WebKit.DOM_C/DOM*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/WebKit.DOM_P/DOM*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/WebKit_C/*.cs) \
	$(filter-out $(wildcard $(LIBRARIES_DIR)/$(NAME)/WebKit_P/WebJavaPlugIn*.cs),$(wildcard $(LIBRARIES_DIR)/$(NAME)/WebKit_P/*.cs)) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/WebKit_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
