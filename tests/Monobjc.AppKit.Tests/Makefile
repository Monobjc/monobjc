## =======================================
## Monobjc.AppKit.Tests Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.AppKit.Tests
REFERENCES=$(DEST_DIR)/Monobjc.dll $(DEST_DIR)/Monobjc.Foundation.dll $(DEST_DIR)/Monobjc.AppKit.dll
SOURCES= \
	$(wildcard $(TESTS_DIR)/Monobjc.Foundation.Tests/Common/*.cs) \
	$(wildcard $(TESTS_DIR)/$(NAME)/*.cs) \
	$(wildcard $(TESTS_DIR)/$(NAME)/Properties/*.cs)
RESOURCES= \
	$(TESTS_DIR)/$(NAME)/MainMenu.nib \
	$(TESTS_DIR)/$(NAME)/MainMenu2.nib.en \
	$(TESTS_DIR)/$(NAME)/Sample.png

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
