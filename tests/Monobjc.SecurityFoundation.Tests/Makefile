## =======================================
## Monobjc.SecurityFoundation.Tests Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.SecurityFoundation.Tests
REFERENCES=$(DEST_DIR)/Monobjc.dll $(DEST_DIR)/Monobjc.Foundation.dll $(DEST_DIR)/Monobjc.Security.dll $(DEST_DIR)/Monobjc.SecurityFoundation.dll
SOURCES= \
	$(wildcard $(TESTS_DIR)/Monobjc.Foundation.Tests/Common/*.cs) \
	$(wildcard $(TESTS_DIR)/$(NAME)/*.cs) \
	$(wildcard $(TESTS_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
