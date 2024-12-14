# Makefile for gba_EEPROM_reverse program

# Compiler and flags
CC = gcc
CFLAGS = -Wall -O2

# Source and binary files
SRC = gba_EEPROM_reverse.c
EXEC = gba_EEPROM_reverse

# Default target
all: $(EXEC)

# Build the executable
$(EXEC): $(SRC)
	$(CC) $(CFLAGS) -o $(EXEC) $(SRC)

# Clean up build artifacts
clean:
	rm -f $(EXEC)

.PHONY: all clean
