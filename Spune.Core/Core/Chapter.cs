//--------------------------------------------------------------------------------------------------
// <copyright company="NHL Stenden">
//     Author: Martin Bosgra
//     Copyright © NHL Stenden. All rights reserved.
// </copyright>
//--------------------------------------------------------------------------------------------------

namespace Spune.Core.Core;

/// <summary>
/// Specifies the type of content.
/// </summary>
public enum Content
{

    /// <summary>
    /// Represents a text content type.
    /// </summary>
    Text,
    /// <summary>
    /// Represents a table content type.
    /// </summary>
    Table
}

/// <summary>
/// Represents a chapter within a master story, containing an identifier and a collection of interactions.
/// </summary>
public class Chapter : SubElement, IDisposable
{
    /// <summary>
    /// The chat fallback member.
    /// </summary>
    string _chatFallback = string.Empty;

    /// <summary>
    /// The chat message member.
    /// </summary>
    string _chatMessage = string.Empty;

    /// <summary>
    /// The close delay member.
    /// </summary>
    double _closeDelay;

    /// <summary>
    /// The content member.
    /// </summary>
    Content _content = Content.Text;

    /// <summary>
    /// The inventory conditions member.
    /// </summary>
    string _inventoryConditions = string.Empty;

    /// <summary>
    /// The inventory is visible member.
    /// </summary>
    bool _inventoryIsVisible;

    /// <summary>
    /// The is end member.
    /// </summary>
    bool _isEnd;

    /// <summary>
    /// The is start member.
    /// </summary>
    bool _isStart;

    /// <summary>
    /// Indicates whether the media resources linked to the element have been disposed.
    /// This flag is used to ensure that media resources are released only once during the object's lifecycle.
    /// </summary>
    bool _mediaDisposed;

    /// <summary>
    /// Randomize interactions member.
    /// </summary>
    bool _randomizeInteractions;

    /// <summary>
    /// Gets or sets the AI response (chat message) for the element if the AI can't respond for some reason. It's a fallback
    /// value.
    /// </summary>
    public string ChatFallback
    {
        get => _chatFallback;
        set
        {
            _chatFallback = value;
            NotifyPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets the AI prompt (chat message) for the element. This property defines the input
    /// text that can be processed by an AI system to generate a response or text completion.
    /// It serves as a starting point for AI-based text generation processes within this class.
    /// </summary>
    public string ChatMessage
    {
        get => _chatMessage;
        set
        {
            _chatMessage = value;
            NotifyPropertyChanged();
        }
    }

    /// <summary>
    /// Represents an automatic close with a delay (in ms) for the element. 0 means do not use.
    /// </summary>
    public double CloseDelay
    {
        get => _closeDelay;
        set
        {
            _closeDelay = value;
            NotifyPropertyChanged();
        }
    }

    /// <summary>
    /// Represents the content for the element.
    /// </summary>
    public Content Content
    {
        get => _content;
        set
        {
            _content = value;
            NotifyPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets the inventory conditions.
    /// </summary>
    public string InventoryConditions
    {
        get => _inventoryConditions;
        set
        {
            _inventoryConditions = value;
            NotifyPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets the visibility for the inventory.
    /// </summary>
    public bool InventoryIsVisible
    {
        get => _inventoryIsVisible;
        set
        {
            _inventoryIsVisible = value;
            NotifyPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets the is end flag.
    /// </summary>
    public bool IsEnd
    {
        get => _isEnd;
        set
        {
            _isEnd = value;
            NotifyPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets the is start flag.
    /// </summary>
    public bool IsStart
    {
        get => _isStart;
        set
        {
            _isStart = value;
            NotifyPropertyChanged();
        }
    }

    /// <summary>
    /// Represents a media object associated with an element,
    /// providing support for managing image and audio content,
    /// including loading, accessing, and determining the presence of media.
    /// </summary>
    public Media Media { get; set; } = new();

    /// <summary>
    /// Randomize the property Interactions.
    /// </summary>
    public bool RandomizeInteractions
    {
        get => _randomizeInteractions;
        set
        {
            _randomizeInteractions = value;
            NotifyPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets the collection of interactions associated with the chapter.
    /// Each interaction represents an actionable element or decision point
    /// within the chapter's context.
    /// </summary>
    public ObservableCollection<Interaction> Interactions { get; set; } = [];

    /// <inheritdoc />
    public override bool HasText() => !string.IsNullOrEmpty(ChatMessage) || base.HasText();

    /// <summary>
    /// Checks if there are inventory conditions.
    /// </summary>
    /// <returns>True if there is, and false otherwise.</returns>
    public bool HasInventoryConditions() => !string.IsNullOrEmpty(_inventoryConditions);

    /// <inheritdoc />
    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    void Dispose(bool disposing)
    {
        if (_mediaDisposed) return;
        if (!disposing) return;
        Media.Dispose();
        _mediaDisposed = true;
    }
}