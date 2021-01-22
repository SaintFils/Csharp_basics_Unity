﻿using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace TrashBucked.Scripts
{
    public sealed class ListInteractableObject : IEnumerable, IEnumerator
    {
        private InteractiveObject[] _interactiveObjects;
        private int _index = -1;
        private InteractiveObject _current;
        
        public ListInteractableObject()
        {
            _interactiveObjects = Object.FindObjectsOfType<InteractiveObject>();
        }

        public bool MoveNext()
        {
            if (_index == _interactiveObjects.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;
        public object Current => _interactiveObjects[_index];
        
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}