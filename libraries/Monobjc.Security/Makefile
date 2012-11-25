## =======================================
## Monobjc.Security Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.Security
REFERENCES=-r:"$(DEST_DIR)/Monobjc.dll" -r:"$(DEST_DIR)/Monobjc.Foundation.dll"
HAS_RESX=0
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Security_E/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Security_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Security_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Security_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
