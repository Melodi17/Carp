```carp
obj loadjson(str json)
```
> Loads a JSON string and converts it into a Carp object.

---

```carp
!CarpMatchResult! match(str pattern, str text)
```
> Converts a dynamic object into a Carp object.

---

```carp
!CarpCollection!* matches(str pattern, str text)
```
> Matches a regular expression pattern against a text and returns all matches.

---

```carp
str replace(str pattern, str text, str replacement)
```
> Replaces all occurrences of a regular expression pattern in a text with a replacement string.

---

```carp
!CarpCollection!* split(str pattern, str text)
```
> Splits a text into an array of strings based on a regular expression pattern.

---

```carp
bool test(str pattern, str text)
```
> Tests if a regular expression pattern matches a text.

---