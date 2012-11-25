## =======================================
## Monobjc.CoreWLAN Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.CoreWLAN
REFERENCES=$(DEST_DIR)/Monobjc.dll $(DEST_DIR)/Monobjc.Foundation.dll $(DEST_DIR)/Monobjc.Security.dll $(DEST_DIR)/Monobjc.SecurityFoundation.dll
HAS_RESX=0
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CoreWLAN_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CoreWLAN_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
