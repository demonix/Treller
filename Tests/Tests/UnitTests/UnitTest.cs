﻿using SKBKontur.Treller.Tests.MockWrappers;

namespace SKBKontur.Treller.Tests.Tests.UnitTests
{
    public abstract class UnitTest
    {
        protected readonly MyMock mock;

        protected UnitTest()
        {
            mock = new MyMock();
        }

        ~UnitTest()
        {
            mock.Dispose();
            mock.RunAll();
        }
    }
}