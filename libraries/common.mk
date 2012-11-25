## =======================================
## Monobjc Library Makefile
## =======================================

# ----------------------------------------
# Variables
# ----------------------------------------

DEFINES?=DEBUG
TARGET=$(DEST_DIR)/$(NAME).dll
XML_DOC=$(DEST_DIR)/$(NAME).xml

ifeq ($(HAS_RESX),1)
	RESX=$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.resx)
	RESOURCES=$(patsubst %.resx,%.resources,$(RESX))
	RESOURCES_ARGUMENT=-resource:$(RESOURCES)
else
	RESX=
	RESOURCES=
	RESOURCES_ARGUMENT=
endif

# ----------------------------------------
# Targets
# ----------------------------------------

all: $(TARGET)

clean:

$(RESOURCES): $(RESX)
	$(RESGEN) $(RESX) $(RESOURCES)

$(TARGET): $(SOURCES) $(RESOURCES)
	$(MCS) -target:library -out:"$(TARGET)" -define:"$(DEFINES)" $(REFERENCES) $(RESOURCES_ARGUMENT) $(SOURCES) -doc:$(XML_DOC)
