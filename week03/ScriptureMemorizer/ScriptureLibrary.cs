public class ScriptureLibrary
{
    private List<(Reference reference, string text)> _scriptures;
    private Random _rand = new Random();

    public ScriptureLibrary()
    {
        _scriptures = new List<(Reference, string)>
        {
            (new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),

            (new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),

            (new Reference("1 Nephi", 3, 7),
            "I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."),

            (new Reference("Mosiah", 2, 17),
            "When ye are in the service of your fellow beings ye are only in the service of your God."),

            (new Reference("Alma", 32, 21),
            "Faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true."),

            (new Reference("Ether", 12, 27),
            "If men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me."),

            (new Reference("Doctrine and Covenants", 1, 38),
            "Whether by mine own voice or by the voice of my servants, it is the same."),

            (new Reference("Doctrine and Covenants", 89, 18, 21),
            "And all saints who remember to keep and do these sayings, walking in obedience to the commandments, shall receive health in their navel and marrow to their bones; And shall find wisdom and great treasures of knowledge, even hidden treasures; And shall run and not be weary, and shall walk and not faint.")
        };
    }

    public (Reference reference, string text) GetRandomScripture()
    {
        int index = _rand.Next(_scriptures.Count);
        return _scriptures[index];
    }
}