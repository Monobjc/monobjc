## =======================================
## Monobjc.CorePlot Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.CorePlot
REFERENCES=-r:"$(DEST_DIR)/Monobjc.dll" -r:"$(DEST_DIR)/Monobjc.Foundation.dll" -r:"$(DEST_DIR)/Monobjc.AppKit.dll"
HAS_RESX=0
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CorePlot_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CorePlot_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CorePlot_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CorePlot_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
