using System;
using System.Xml;
using Microsoft.VisualStudio.TestTools.Common;
using Microsoft.VisualStudio.TestTools.Execution;

namespace NyanCatReporterDataCollector
{
    [DataCollectorTypeUri("datacollector://Nyan/Cat/1.0")]
    [DataCollectorFriendlyName("NyanCat Reporter", false)]
    public class TestRunDataCollector : DataCollector
    {
        private DataCollectionEvents _dataEvents;
        private DataCollectionLogger _dataLogger;
        private DataCollectionSink _dataSink;
        private XmlElement _configSettings;
        private CatRenderer _nyanCat;
        private TestStats _stats;

        public override void Initialize(XmlElement configurationElement, DataCollectionEvents events,
            DataCollectionSink dataSink, DataCollectionLogger logger, DataCollectionEnvironmentContext environmentContext)
        {
            _dataEvents = events;
            _dataLogger = logger;
            _dataSink = dataSink;

            _configSettings = configurationElement;
            RegisterEventHandlers();

            _nyanCat = new CatRenderer();
            _stats = new TestStats();
        }

        private void RegisterEventHandlers()
        {
            _dataEvents.SessionStart += new EventHandler<SessionStartEventArgs>(OnSessionStart);
            _dataEvents.SessionEnd += new EventHandler<SessionEndEventArgs>(OnSessionEnd);
            _dataEvents.TestCaseStart += new EventHandler<TestCaseStartEventArgs>(OnTestCaseStart);
            _dataEvents.TestCaseEnd += new EventHandler<TestCaseEndEventArgs>(OnTestCaseEnd);
        }

        private void OnTestCaseEnd(object sender, TestCaseEndEventArgs e)
        {
            if (e.TestOutcome == TestOutcome.Passed)
                _stats.Passed += 1;
            else if (e.TestOutcome == TestOutcome.Failed)
                _stats.Failed += 1;
            else
                _stats.Other += 1;

            _nyanCat.UpdateStats(_stats);
        }

        private void OnTestCaseStart(object sender, TestCaseStartEventArgs e)
        {
        }

        private void OnSessionStart(object sender, SessionStartEventArgs e)
        {
            _nyanCat.Start();
        }

        private void OnSessionEnd(object sender, SessionEndEventArgs e)
        {
            _nyanCat.Stop();
        }
    }
}

