# Reads the content of a file at the given path.
str readfile(str path)

# Reads all lines from a file at the given path.
!CarpCollection!* readfilelines(str path)

# Writes the specified content to a file at the given path.
void writefile(str path, str cont)

# Writes the specified lines to a file at the given path.
void writefilelines(str path, !CarpCollection!* cont)

# Checks if a file or directory exists at the given path.
bool exists(str path)

# Deletes a file at the given path.
void delete(str path)

# Creates a directory at the given path.
void createdir(str path)

# Deletes a directory at the given path.
void deletedir(str path)

# Lists all files in a directory at the given path.
!CarpCollection!* listdir(str path)

# Lists all directories in a directory at the given path.
!CarpCollection!* listdirs(str path)