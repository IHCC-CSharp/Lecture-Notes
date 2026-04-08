# Interface Diagram

## One Takeaway

Build an interface when multiple classes need the same behavior and you want the code using them to stay unchanged.

## 1) Why build an interface?

```mermaid
flowchart TD
    A[Start with one class: Circle] --> B[App code uses Circle directly]
    B --> C[New requirement: add Square]
    C --> D[Now app code must know about Circle and Square]
    D --> E[More shapes means more changes in the app code]
    E --> F[Create IShape]
    F --> G[Move shared behavior into the interface]
    G --> H[App code depends on IShape instead of concrete classes]
    H --> I[New shapes can be added with less change to the app code]
```

## 2) Where the pain is without an interface

```mermaid
flowchart LR
    A[Console app] --> B[Circle-specific code]
    A --> C[Square-specific code]
    B --> D[Describe circle]
    B --> E[Get circle area]
    C --> F[Describe square]
    C --> G[Get square area]
    H[Problem] --> I[The app has to know too much about each class]
```

## 3) Structure with one interface

```mermaid
classDiagram
    class IShape {
        <<interface>>
        +GetArea() double
        +Describe() string
    }

    class Circle {
        +Radius: double
        +Circle(radius: double)
        +GetArea() double
        +Describe() string
    }

    class Square {
        +SideLength: double
        +Square(sideLength: double)
        +GetArea() double
        +Describe() string
    }

    IShape <|.. Circle
    IShape <|.. Square
```

## 4) What changes after introducing IShape

The interface couples the app together.

```mermaid
flowchart LR
    A[Console app] --> B[IShape variable]
    B --> C[Describe]
    B --> D[GetArea]
    E[Circle] --> B
    F[Square] --> B
    G[Benefit] --> H[The app uses one contract for both classes]
```
