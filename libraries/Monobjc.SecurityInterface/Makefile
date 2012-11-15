## =======================================
## Monobjc.SecurityInterface Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.SecurityInterface
DEFINES?=DEBUG
TARGET=$(DEST_DIR)/$(NAME).dll
REFERENCES=-r:"$(DEST_DIR)/Monobjc.dll" -r:"$(DEST_DIR)/Monobjc.Foundation.dll"
RESX=
RESOURCES=
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SecurityInterface_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SecurityInterface_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SecurityInterface_P/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/SecurityInterface_T/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Targets
# ----------------------------------------

all: $(TARGET)

clean:

$(TARGET): $(SOURCES)
	$(MCS) -target:library -out:"$(TARGET)" -define:"$(DEFINES)" $(REFERENCES) $(SOURCES)
