## =======================================
## Monobjc.EventKit Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.EventKit
REFERENCES=$(DEST_DIR)/Monobjc.dll $(DEST_DIR)/Monobjc.Foundation.dll $(DEST_DIR)/Monobjc.AppKit.dll $(DEST_DIR)/Monobjc.AddressBook.dll $(DEST_DIR)/Monobjc.CoreLocation.dll
HAS_RESX=0
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/EventKit_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/EventKit_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
