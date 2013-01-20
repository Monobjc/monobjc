## =======================================
## Monobjc.Foundation.Tests Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.Foundation.Tests
REFERENCES=$(DEST_DIR)/Monobjc.dll $(DEST_DIR)/Monobjc.Foundation.dll
SOURCES= \
	$(wildcard $(TESTS_DIR)/$(NAME)/*.cs) \
	$(wildcard $(TESTS_DIR)/$(NAME)/Common/*.cs) \
	$(wildcard $(TESTS_DIR)/$(NAME)/Properties/*.cs)
RESOURCES= \
	$(TESTS_DIR)/$(NAME)/Encrypted.png

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
