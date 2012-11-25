## =======================================
## Monobjc.SecurityInterface Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.SecurityInterface
REFERENCES=-r:"$(DEST_DIR)/Monobjc.dll" -r:"$(DEST_DIR)/Monobjc.Foundation.dll" -r:"$(DEST_DIR)/Monobjc.AppKit.dll" -r:"$(DEST_DIR)/Monobjc.Security.dll" -r:"$(DEST_DIR)/Monobjc.SecurityFoundation.dll"
HAS_RESX=0
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(filter-out $(wildcard $(LIBRARIES_DIR)/$(NAME)/SecurityInterface_C/SFAuthorizationPluginView*.cs),$(wildcard $(LIBRARIES_DIR)/$(NAME)/SecurityInterface_C/*.cs)) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SecurityInterface_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SecurityInterface_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SecurityInterface_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
