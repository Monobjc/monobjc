## =======================================
## Monobjc.ScriptingBridge Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.ScriptingBridge
REFERENCES=$(DEST_DIR)/Monobjc.dll $(DEST_DIR)/Monobjc.Foundation.dll
HAS_RESX=0
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/ScriptingBridge_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/ScriptingBridge_E/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/ScriptingBridge_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
