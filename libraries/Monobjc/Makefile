## =======================================
## Monobjc Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc
DEFINES?=DEBUG
TARGET=$(DEST_DIR)/$(NAME).dll
XML_DOC=$(DEST_DIR)/$(NAME).xml
REFERENCES=
RESX=$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.resx)
RESOURCES=$(patsubst %.resx,%.resources,$(RESX))
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Generators/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Runtime/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Utils/*.cs)

# ----------------------------------------
# Targets
# ----------------------------------------

all: $(TARGET)

clean:

$(RESOURCES): $(RESX)
	$(RESGEN) $(RESX) $(RESOURCES)

$(TARGET): $(SOURCES) $(RESOURCES)
	$(MCS) -target:library -out:"$(TARGET)" -define:"$(DEFINES)" $(REFERENCES) -resource:$(RESOURCES) $(SOURCES) -doc:$(XML_DOC)
