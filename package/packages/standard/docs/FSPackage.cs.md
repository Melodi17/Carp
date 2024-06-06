```carp
str readfile(str path)
```
> Reads the content of a file at the given path.

---

```carp
!CarpCollection!* readfilelines(str path)
```
> Reads all lines from a file at the given path.

---

```carp
void writefile(str path, str cont)
```
> Writes the specified content to a file at the given path.

---

```carp
void writefilelines(str path, !CarpCollection!* cont)
```
> Writes the specified lines to a file at the given path.

---

```carp
bool exists(str path)
```
> Checks if a file or directory exists at the given path.

---

```carp
void delete(str path)
```
> Deletes a file at the given path.

---

```carp
void createdir(str path)
```
> Creates a directory at the given path.

---

```carp
void deletedir(str path)
```
> Deletes a directory at the given path.

---

```carp
!CarpCollection!* listdir(str path)
```
> Lists all files in a directory at the given path.

---

```carp
!CarpCollection!* listdirs(str path)
```
> Lists all directories in a directory at the given path.

---