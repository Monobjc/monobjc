## =======================================
## Monobjc.DiscRecording Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.DiscRecording
REFERENCES=$(DEST_DIR)/Monobjc.dll $(DEST_DIR)/Monobjc.Foundation.dll
HAS_RESX=0
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/DiscRecording_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/DiscRecording_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/DiscRecording_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
