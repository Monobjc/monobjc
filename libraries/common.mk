## =======================================
## Common Library Makefile
## =======================================

# ----------------------------------------
# Variables
# ----------------------------------------

DEFINES?=DEBUG
TARGET=$(DEST_DIR)/$(NAME).dll
XML_DOC=$(DEST_DIR)/$(NAME).xml
REFERENCES?= 

ifeq ($(REFERENCES), )
	REFERENCES_ARGUMENT=
else
	REFERENCES_ARGUMENT=$(addprefix -r:,$(REFERENCES))
endif

ifeq ($(HAS_RESX),1)
	RESX=$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.resx)
	RESOURCES=$(patsubst %.resx,%.resources,$(RESX))
	RESOURCES_ARGUMENT=$(foreach r,$(RESOURCES),-resource:$r,$(NAME).Properties.$(notdir $r))
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

$(REFERENCES):
	$(error Missing dependency $@)

$(RESOURCES): $(RESX)
	$(RESGEN) $(RESX) $(RESOURCES)

$(TARGET): $(REFERENCES) $(SOURCES) $(RESOURCES)
	$(MCS) -target:library -out:"$(TARGET)" -define:"$(DEFINES)" $(REFERENCES_ARGUMENT) $(RESOURCES_ARGUMENT) $(SOURCES) -doc:$(XML_DOC)

# ----------------------------------------
# Phony Targets
# ----------------------------------------

.PHONY: \
	all \
	clean
