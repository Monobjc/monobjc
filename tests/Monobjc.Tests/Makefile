## =======================================
## Monobjc.Tests Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.Tests
REFERENCES=$(DEST_DIR)/Monobjc.dll
SOURCES= \
	$(wildcard $(TESTS_DIR)/$(NAME)/*.cs) \
	$(wildcard $(TESTS_DIR)/$(NAME)/Generators/*.cs) \
	$(wildcard $(TESTS_DIR)/$(NAME)/Generators/Cecil/*.cs) \
	$(wildcard $(TESTS_DIR)/$(NAME)/Properties/*.cs) \
	$(wildcard $(TESTS_DIR)/$(NAME)/Types/*.cs) \
	$(wildcard $(TESTS_DIR)/$(NAME)/Utils/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
