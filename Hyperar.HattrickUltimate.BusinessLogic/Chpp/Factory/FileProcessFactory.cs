namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Factory
{
    using System;
    using BusinessObjects.Hattrick.Interface;
    using Interface;

    internal class FileProcessFactory : IFileProcessFactory
    {
        #region Public Methods

        public IFileProcessStrategy GetFor(IXmlEntity entity)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}