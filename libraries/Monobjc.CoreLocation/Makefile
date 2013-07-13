## =======================================
## Monobjc.CoreLocation Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.CoreLocation
REFERENCES=$(DEST_DIR)/Monobjc.dll $(DEST_DIR)/Monobjc.Foundation.dll $(DEST_DIR)/Monobjc.AppKit.dll
HAS_RESX=0
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
    $(wildcard $(LIBRARIES_DIR)/$(NAME)/CoreLocation_C/*.cs) \
    $(wildcard $(LIBRARIES_DIR)/$(NAME)/CoreLocation_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CoreLocation_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CoreLocation_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CoreLocation_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
