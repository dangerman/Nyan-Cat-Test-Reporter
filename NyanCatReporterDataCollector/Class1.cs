using System;
using System.Windows.Forms;
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

        public override void Initialize(XmlElement configurationElement, DataCollectionEvents events,
            DataCollectionSink dataSink, DataCollectionLogger logger, DataCollectionEnvironmentContext environmentContext)
        {
            _dataEvents = events;
            _dataLogger = logger;
            _dataSink = dataSink;

            _configSettings = configurationElement;
            RegisterEventHandlers();
        }

        private void RegisterEventHandlers()
        {
            _dataEvents.SessionStart += new EventHandler<SessionStartEventArgs>(OnSesstionStart);
            _dataEvents.SessionEnd += new EventHandler<SessionEndEventArgs>(OnSessionEnd);
            _dataEvents.TestCaseStart += new EventHandler<TestCaseStartEventArgs>(OnTestCaseStart);
            _dataEvents.TestCaseEnd += new EventHandler<TestCaseEndEventArgs>(OnTestCaseEnd);
        }

        private void OnTestCaseEnd(object sender, TestCaseEndEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnTestCaseStart(object sender, TestCaseStartEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnSessionEnd(object sender, SessionEndEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnSesstionStart(object sender, SessionStartEventArgs e)
        {
            //MessageBox.Show("session started");
            throw new NotImplementedException();
        }
    }
}

