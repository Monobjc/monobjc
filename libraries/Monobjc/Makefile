## =======================================
## Monobjc Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc
REFERENCES=
HAS_RESX=1
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Generators/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Runtime/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Utils/*.cs)

# ----------------------------------------
# Common
# ----------------------------------------

include ../common.mk
