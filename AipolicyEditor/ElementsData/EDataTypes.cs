namespace KuklusDataEditor.Core
{
    public enum EDataTypes : byte
    {
        ENull, // None
        EInt32, // 4 bytes int32
        EFloat, // 4 bytes single
        EUString, // Unicode string
        ECString, // GBK string
        EColor, // Color selector
        EItem, // Item id
        EItemProb, // Item id and prob
        EItemCount, // Item id and count
        EAddon, // Addon id
        EAddonProb, // Addon id and prob
        ELink, // Link to other list
        EPepared, // 
        EMask, // Mask converter
        EID, // Item id
        EName, // Item name
        EIcon, // Item icon
        EModel, // Model
    }
}
