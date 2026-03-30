namespace BodyBuddy;

public class User
{
    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// Use this constructor to create a new, unique user. The ID will be generated automatically.
    /// </summary>
    /// <param name="name">The name of this user.</param>
    public User(string name)
    {
        ID = Guid.NewGuid().ToString();
        Name = name;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// If the ID must be provided, such as to restore save state, this constructor
    /// may be used. Prefer `User(string name)` otherwise, to create a unique user.
    /// </summary>
    /// <param name="id">The ID of this user.</param>
    /// <param name="name">The name of this user.</param>
    public User(string id, string name)
    {
        ID = id;
        Name = name;
    }

    /// <summary>
    /// Gets the ID is a unique, permanent identifier for this user.
    /// </summary>
    public string ID { get; }

    /// <summary>
    /// Gets or sets the user's name. This is not unique and can be changed at any time.
    /// This should only be used to display the user, not as a unique identifier.
    /// </summary>
    public string Name { get; set; }

    public string AsFileEntry()
    {
        return $"{ID}: {Name}";
    }
}
