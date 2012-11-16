## =======================================
## Monobjc.Social Library Makefile
## =======================================

include ../../Monobjc.mk

# ----------------------------------------
# Variables
# ----------------------------------------

NAME=Monobjc.Social
DEFINES?=DEBUG
TARGET=$(DEST_DIR)/$(NAME).dll
REFERENCES=-r:"$(DEST_DIR)/Monobjc.dll" -r:"$(DEST_DIR)/Monobjc.Foundation.dll" -r:"$(DEST_DIR)/Monobjc.Accounts.dll"
RESX=
RESOURCES=
SOURCES= \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Social_C/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Social_Extensions/*.cs) \
	$(wildcard $(LIBRARIES_DIR)/$(NAME)/Properties/*.cs)

# ----------------------------------------
# Targets
# ----------------------------------------

all: $(TARGET)

clean:

$(TARGET): $(SOURCES)
	$(MCS) -target:library -out:"$(TARGET)" -define:"$(DEFINES)" $(REFERENCES) $(SOURCES)
