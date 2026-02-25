---
marp: true
theme: gaia
class: invert
paginate: true
backgroundColor: #1e1e1e
---

# Abstraction

## Why hide complexity?

By: Luke Matheis

---

# Microsoft Loves 4 ways to do things

Properties sit on a scale between simplicity and control.

* Public Fields: Simplest, but zero control.
* Auto-Properties: Great for simple data.
* Semi-Auto Properties: Middle ground logic.
* Full Properties: Maximum logic and control.
* Methods: Most flexible but most complex.

---

![bg contain](assets/CSharpMSJava.webp)

---

![bg contain](assets/Diagram.png)

---

# Full Properties

This is the most versatile type. It requires a private backing field.

* The backing field holds the actual data.
* It is conventionally prefixed with an underscore.

```csharp
private float _width;

public float Width
{
    get { return _width; }
    set { _width = value; }
}

```

---

# Auto-Implemented Properties

Use these when you do not need logic yet. The compiler creates a hidden backing field for you.

* Very clean and concise.
* Best practice for simple data storage.

```csharp
public class Light
{
    public bool IsOn { get; set; }
}

```

---

# Field-Backed Properties (.NET 10)

Also known as semi-auto properties. They use the `field` keyword.

* No need to declare a private variable.
* You can still add logic to the setter.

```csharp
public float Width
{
    get;
    set => field = Math.Max(0, value);
}

```

---

# Property vs. Method

* Use a Property if:
    - It feels like an attribute (Size, Color).
    - The operation is fast.
* Use a Method if:
    - It feels like an action (CalculateTotal).
    - It involves a lot of computation.

---

# Summary

* Full Property: Manual field and manual logic.
* Auto-Property: Shortcut for simple data.
* Semi-Auto: Shortcut that still allows logic.
* Mastering full properties gives you the most control over your objects.

---
