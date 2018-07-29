// <copyright file="enums.cs" company="Peter Ibbotson">
// (C) Copyright 2018 Peter Ibbotson
// </copyright>

namespace Rockstar.Interpreter
{
    /// <summary>
    /// Error codes for the interpreter / parser.
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Error code when a common variable has characters out of the range a-z.
        /// </summary>
        BadCharactersInCommonVariable = 1,

        /// <summary>
        /// Error code when a string is not terminated.
        /// </summary>
        UnterminatedString = 2,
    }

    /// <summary>
    /// Class of the token.
    /// </summary>
    public enum TokenClass
    {
        /// <summary>Token is a keyword.</summary>
        Keyword,

        /// <summary>Token is text or otherwise unknown value.</summary>
        Text,

        /// <summary>Token is string literal.</summary>
        StringLiteral,

        /// <summary>Token is a common variable.</summary>
        CommonVariable,

        /// <summary>Token is a proper variable.</summary>
        ProperVariable,
    }

    /// <summary>
    /// Enum for the keywords within the system.
    /// </summary>
    public enum Keyword
    {
        /// <summary>Returned if we have no match at all.</summary>
        NoMatch,

        /// <summary>Ain't keyword.</summary>
        Aint,

        /// <summary>And keyword.</summary>
        And,

        /// <summary>And Around we go keyword.</summary>
        AndAroundWeGoAround,

        /// <summary>Around</summary>
        Around,

        /// <summary>Back keyword.</summary>
        Back,

        /// <summary>False keyword.</summary>
        BoolFalse,

        /// <summary>True keyword.</summary>
        BoolTrue,

        /// <summary>keyword.</summary>
        Break,

        /// <summary>keyword.</summary>
        Build,

        /// <summary>keyword.</summary>
        Comma,

        /// <summary>keyword.</summary>
        Continue,

        /// <summary>keyword.</summary>
        Definitely,

        /// <summary>keyword.</summary>
        DefinitelyMaybe,

        /// <summary>Down keyword.</summary>
        Down,

        /// <summary>Down! keyword.</summary>
        DownPling,

        /// <summary>End keyword.</summary>
        End,

        /// <summary>From keyword.</summary>
        From,

        /// <summary>Give keyword.</summary>
        Give,

        /// <summary>Go keyword.</summary>
        Go,

        /// <summary>keyword.</summary>
        HigherGreaterBiggerStronger,

        /// <summary>keyword.</summary>
        If,

        /// <summary>keyword.</summary>
        Into,

        /// <summary>keyword.</summary>
        IsWasWere,

        /// <summary>keyword.</summary>
        ItHeSheHimHerThemThey,

        /// <summary>Knock keyword.</summary>
        Knock,

        /// <summary>Listen to.</summary>
        Listen,

        /// <summary>Lower, Less, Smaller and Weaker keyword.</summary>
        LowerLessSmallerWeaker,

        /// <summary>Maybe keyword.</summary>
        Maybe,

        /// <summary>My, Our or Your keyword.</summary>
        MyOurYour,

        /// <summary>Mysterious keyword.</summary>
        Mysterious,

        /// <summary>Not keyword.</summary>
        Not,

        /// <summary>Null, Nothing, Nowhere and Nobody keyword.</summary>
        NullNothingNowhereNobody,

        /// <summary>Put keyword.</summary>
        Put,

        /// <summary>Say, Shout, Wisper and scream keyword.</summary>
        SayShoutWisperScream,

        /// <summary>Says keyword.</summary>
        Says,

        /// <summary>Than keyword.</summary>
        Than,

        /// <summary>The keyword.</summary>
        The,

        /// <summary>Take keyword.</summary>
        Take,

        /// <summary>Takes keyword.</summary>
        Takes,

        /// <summary>Taking keyword.</summary>
        Taking,

        /// <summary>To keyword.</summary>
        To,

        /// <summary>Top keyword.</summary>
        Top,

        /// <summary>Until keyword.</summary>
        Until,

        /// <summary>Up keyword.</summary>
        Up,

        /// <summary>We keyword.</summary>
        We,

        /// <summary>While keyword.</summary>
        While,
    }
}
