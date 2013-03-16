## =======================================
## Monobjc.Foundation Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.Foundation
REFERENCES=$(DEST_DIR)/Monobjc.dll
HAS_RESX=1
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/ApplicationServices_E/CG*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/ApplicationServices_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/ApplicationServices_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/CoreFoundation_T/CFType.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Foundation_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Foundation_Collections/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Foundation_E/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Foundation_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Foundation_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Foundation_S/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Foundation_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Kernel_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Kernel_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs) \
	$(wildcard $(TOOLS_DIR)/Monobjc.Tools/Generators/FileEncrypter.Public.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
