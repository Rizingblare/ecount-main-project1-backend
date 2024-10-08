﻿namespace Command
{
    public class BaseEntity<TKey> : IEntity<TKey>
        where TKey : IEntityKey, new()
    {
        private TKey _key;
        public TKey Key
        {
            get
            {
                if (_key == null)
                {
                    _key = new TKey();
                }
                return _key;
            }
            set
            {
                _key = value;
            }
        }
    }
}
