## =======================================
## Monobjc.MapKit Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.MapKit
REFERENCES=$(DEST_DIR)/Monobjc.dll $(DEST_DIR)/Monobjc.Foundation.dll $(DEST_DIR)/Monobjc.AppKit.dll $(DEST_DIR)/Monobjc.CoreLocation.dll
HAS_RESX=0
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/MapKit_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/MapKit_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/MapKit_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/MapKit_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/MapKit_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
