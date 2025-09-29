using Newtonsoft.Json;



namespace Nop.Core.Configuration
{
    public class AzureBlobConfig : IConfig
    {
        public string AccountName { get; protected set; } = string.Empty;
        public string AccountKey { get; protected set; } = string.Empty;
        public string BlobEndpoint { get; protected set; } = string.Empty;
        public string ContainerName { get; protected set; } = string.Empty;
        /// Gets or sets connection string for Azure Blob storage
        /// ex: DefaultEndpointsProtocol=https;AccountName=myaccount;AccountKey=myaccountkey;
        ///     BlobEndpoint=[https://myaccount.blob.core.windows.net/](https://myaccount.blob.core.windows.net/)

        public string ConnectionString { get; protected set; } = string.Empty;
        /// <summary>
        /// StorageUri to AppendAccountName to BlobEndpoint
        /// </summary>
        public Uri StorageUri { get; protected set; } 
        public string DataProtectionKeysVaultId { get; protected set; } = string.Empty;

        /// <summary>
        /// Gets a value indicating whether we should use Azure Blob storage
        /// </summary>
        [JsonIgnore]
        public bool Enabled => !string.IsNullOrEmpty(ConnectionString);

        /// <summary>
        /// Whether to use an Azure Key Vault to encrypt the Data Protection Keys
        /// </summary>
        [JsonIgnore]
        public bool DataProtectionKeysEncryptWithVault => !string.IsNullOrEmpty(DataProtectionKeysVaultId);

        /* AzureBlobConfig - NopCommerce*/
        ///// <summary>
        ///// Gets or sets connection string for Azure Blob storage
        ///// </summary>
        //public string ConnectionString { get; protected set; } = string.Empty;

        ///// <summary>
        ///// Gets or sets container name for Azure Blob storage
        ///// </summary>
        //public string ContainerName { get; protected set; } = string.Empty;

        ///// <summary>
        ///// Gets or sets end point for Azure Blob storage
        ///// </summary>
        //public string EndPoint { get; protected set; } = string.Empty;

        ///// <summary>
        ///// Gets or sets whether or the Container Name is appended to the AzureBlobStorageEndPoint when constructing the url
        ///// </summary>
        //public bool AppendContainerName { get; protected set; } = true;

        ///// <summary>
        ///// Gets or sets whether to store Data Protection Keys in Azure Blob Storage
        ///// </summary>
        //public bool StoreDataProtectionKeys { get; protected set; } = false;

        ///// <summary>
        ///// Gets or sets the Azure container name for storing Data Protection Keys (this container should be separate from the container used for media and should be Private)
        ///// </summary>
        //public string DataProtectionKeysContainerName { get; protected set; } = string.Empty;

        ///// <summary>
        ///// Gets or sets the Azure key vault ID used to encrypt the Data Protection Keys. (this is optional)
        ///// </summary>
        //public string DataProtectionKeysVaultId { get; protected set; } = string.Empty;
    }
}
