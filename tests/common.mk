## =======================================
## Common Test Library Makefile
## =======================================

# ----------------------------------------
# Variables
# ----------------------------------------

DEFINES?=DEBUG
TARGET=$(DEST_DIR)/$(NAME).dll
REFERENCES?= 
RESOURCES?= 

ifeq ($(REFERENCES), )
	REFERENCES_ARGUMENT=
else
	REFERENCES_ARGUMENT=$(addprefix -r:,$(REFERENCES))
endif
REFERENCES_ARGUMENT+=-r:"$(EXTERNAL_DIR)/nunit.framework.dll" 

ifeq ($(RESOURCES), )
	RESOURCES_ARGUMENT=
else
	RESOURCES_ARGUMENT=$(addprefix -resource:,$(RESOURCES))
endif

# ----------------------------------------
# Targets
# ----------------------------------------

all: $(TARGET)

clean:

$(REFERENCES):
	$(error Missing dependency $@)

$(TARGET): $(REFERENCES) $(SOURCES) $(RESOURCES)
	$(MCS) -target:library -out:"$(TARGET)" -define:"$(DEFINES)" $(REFERENCES_ARGUMENT) $(RESOURCES_ARGUMENT) $(SOURCES)

# ----------------------------------------
# Phony Targets
# ----------------------------------------

.PHONY: \
	all \
	clean
