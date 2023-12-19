using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace NafTestForm.Models
{
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(CodifiedFindings));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (CodifiedFindings)serializer.Deserialize(reader);
    // }

    [XmlRoot(ElementName = "ResponseHeader")]
    public class ResponseHeader
    {
        [XmlAttribute(AttributeName = "FileType")]
        public string FileType { get; set; }

        [XmlAttribute(AttributeName = "FileVersionIdentifier")]
        public DateTime FileVersionIdentifier { get; set; }

        [XmlAttribute(AttributeName = "InstitutionIdentifier")]
        public int InstitutionIdentifier { get; set; }

        [XmlAttribute(AttributeName = "UserName")]
        public object UserName { get; set; }

        [XmlAttribute(AttributeName = "UnderwritingEngineName")]
        public DateTime UnderwritingEngineName { get; set; }

        [XmlAttribute(AttributeName = "UnderwritingResultsDateTime")]
        public string UnderwritingResultsDateTime { get; set; }

        [XmlAttribute(AttributeName = "UnderwritingSubmissionNumber")]
        public int UnderwritingSubmissionNumber { get; set; }
    }

    [XmlRoot(ElementName = "Casefile")]
    public class Casefile
    {

        [XmlAttribute(AttributeName = "FNMCaseIdentifier")]
        public int FNMCaseIdentifier { get; set; }

        [XmlAttribute(AttributeName = "LenderCaseIdentifier")]
        public string LenderCaseIdentifier { get; set; }
    }

    [XmlRoot(ElementName = "Line")]
    public class Line
    {

        [XmlAttribute(AttributeName = "MessageText")]
        public string MessageText { get; set; }
    }

    [XmlRoot(ElementName = "LenderMessageText")]
    public class LenderMessageText
    {

        [XmlElement(ElementName = "Line")]
        public Line Line { get; set; }

        [XmlElement(ElementName = "TableRow")]
        public List<TableRow> TableRow { get; set; }
    }

    [XmlRoot(ElementName = "ConsumerMessageText")]
    public class ConsumerMessageText
    {

        [XmlElement(ElementName = "Line")]
        public Line Line { get; set; }
    }

    [XmlRoot(ElementName = "GuideReference")]
    public class GuideReference
    {

        [XmlAttribute(AttributeName = "GuideType")]
        public int GuideType { get; set; }

        [XmlAttribute(AttributeName = "GuideReferenceIdentifier")]
        public object GuideReferenceIdentifier { get; set; }

        [XmlAttribute(AttributeName = "GuideLinkAddress")]
        public object GuideLinkAddress { get; set; }
    }

    [XmlRoot(ElementName = "Message")]
    public class Message
    {

        [XmlElement(ElementName = "LenderMessageText")]
        public LenderMessageText LenderMessageText { get; set; }

        [XmlElement(ElementName = "ConsumerMessageText")]
        public ConsumerMessageText ConsumerMessageText { get; set; }

        [XmlElement(ElementName = "GuideReference")]
        public GuideReference GuideReference { get; set; }

        [XmlAttribute(AttributeName = "MessageIdentifier")]
        public int MessageIdentifier { get; set; }

        [XmlAttribute(AttributeName = "MessageSeverityTypeCode")]
        public int MessageSeverityTypeCode { get; set; }

        [XmlAttribute(AttributeName = "MessageCategoryTypeCode")]
        public int MessageCategoryTypeCode { get; set; }
    }

    [XmlRoot(ElementName = "Column")]
    public class Column
    {

        [XmlAttribute(AttributeName = "MessageText")]
        public string MessageText { get; set; }
    }

    [XmlRoot(ElementName = "TableRow")]
    public class TableRow
    {

        [XmlElement(ElementName = "Column")]
        public List<Column> Column { get; set; }
    }

    [XmlRoot(ElementName = "CasefileMessages")]
    public class CasefileMessages
    {

        [XmlElement(ElementName = "Message")]
        public List<Message> Message { get; set; }
    }

    [XmlRoot(ElementName = "DocumentationLevelCodes")]
    public class DocumentationLevelCodes
    {

        [XmlAttribute(AttributeName = "RequiredDocumentationTypeCode")]
        public int RequiredDocumentationTypeCode { get; set; }

        [XmlAttribute(AttributeName = "RequiredDocumentationLevelCode")]
        public int RequiredDocumentationLevelCode { get; set; }

        [XmlAttribute(AttributeName = "BorrowerUnparsedName")]
        public string BorrowerUnparsedName { get; set; }

        [XmlAttribute(AttributeName = "_SSN")]
        public int SSN { get; set; }
    }

    [XmlRoot(ElementName = "MICoverage")]
    public class MICoverage
    {

        [XmlAttribute(AttributeName = "MIIdentifierCode")]
        public int MIIdentifierCode { get; set; }
    }

    [XmlRoot(ElementName = "RecommendationCode")]
    public class RecommendationCode
    {

        [XmlAttribute(AttributeName = "UnderwritingRecommendationTypeCode")]
        public int UnderwritingRecommendationTypeCode { get; set; }

        [XmlAttribute(AttributeName = "UnderwritingRecommendationDescription")]
        public string UnderwritingRecommendationDescription { get; set; }
    }

    [XmlRoot(ElementName = "CommunityLending")]
    public class CommunityLending
    {

        [XmlAttribute(AttributeName = "MSAOrCountyName")]
        public object MSAOrCountyName { get; set; }

        [XmlAttribute(AttributeName = "HUDMedianIncomeAmount")]
        public object HUDMedianIncomeAmount { get; set; }

        [XmlAttribute(AttributeName = "HUDIncomeLimitAdjustmentFactor")]
        public object HUDIncomeLimitAdjustmentFactor { get; set; }

        [XmlAttribute(AttributeName = "HUDLendingIncomeLimitAmount")]
        public object HUDLendingIncomeLimitAmount { get; set; }
    }

    [XmlRoot(ElementName = "LoanDetails")]
    public class LoanDetails
    {

        [XmlElement(ElementName = "CommunityLending")]
        public CommunityLending CommunityLending { get; set; }

        [XmlAttribute(AttributeName = "SalesPriceAmount")]
        public double SalesPriceAmount { get; set; }

        [XmlAttribute(AttributeName = "BaseLoanAmount")]
        public double BaseLoanAmount { get; set; }

        [XmlAttribute(AttributeName = "MIAndFundingFeeFinancedAmount")]
        public double MIAndFundingFeeFinancedAmount { get; set; }

        [XmlAttribute(AttributeName = "UnderwritingCalculatedLoanAmount")]
        public double UnderwritingCalculatedLoanAmount { get; set; }

        [XmlAttribute(AttributeName = "MortgageTypeCode")]
        public int MortgageTypeCode { get; set; }

        [XmlAttribute(AttributeName = "LoanMaturityTermMonths")]
        public int LoanMaturityTermMonths { get; set; }

        [XmlAttribute(AttributeName = "LoanAmortizationTypeCode")]
        public int LoanAmortizationTypeCode { get; set; }

        [XmlAttribute(AttributeName = "BuydownIndicator")]
        public string BuydownIndicator { get; set; }

        [XmlAttribute(AttributeName = "InitialBuydownRatePercent")]
        public double InitialBuydownRatePercent { get; set; }

        [XmlAttribute(AttributeName = "BalloonIndicator")]
        public string BalloonIndicator { get; set; }

        [XmlAttribute(AttributeName = "LienPriorityTypeCode")]
        public int LienPriorityTypeCode { get; set; }

        [XmlAttribute(AttributeName = "LoanPurposeTypeCode")]
        public int LoanPurposeTypeCode { get; set; }

        [XmlAttribute(AttributeName = "GSERefinancePurposeTypeCode")]
        public string GSERefinancePurposeTypeCode { get; set; }

        [XmlAttribute(AttributeName = "CurrentFirstMortgageHolderTypeCode")]
        public object CurrentFirstMortgageHolderTypeCode { get; set; }

        [XmlAttribute(AttributeName = "SubordinateLienAmount")]
        public double SubordinateLienAmount { get; set; }

        [XmlAttribute(AttributeName = "RequestedInterestRatePercent")]
        public double RequestedInterestRatePercent { get; set; }

        [XmlAttribute(AttributeName = "PurchasePriceAmount")]
        public double PurchasePriceAmount { get; set; }

        [XmlAttribute(AttributeName = "LTVPercent")]
        public double LTVPercent { get; set; }

        [XmlAttribute(AttributeName = "CLTVPercent")]
        public double CLTVPercent { get; set; }

        [XmlAttribute(AttributeName = "LTVWithoutFinancedMIPercent")]
        public double LTVWithoutFinancedMIPercent { get; set; }

        [XmlAttribute(AttributeName = "CLTVWithoutFinancedMIPercent")]
        public double CLTVWithoutFinancedMIPercent { get; set; }

        [XmlAttribute(AttributeName = "FNMProductPlanIdentifier")]
        public int FNMProductPlanIdentifier { get; set; }

        [XmlAttribute(AttributeName = "FNMCommunityLendingProductName")]
        public string FNMCommunityLendingProductName { get; set; }

        [XmlAttribute(AttributeName = "FNMNeighborsMortgageEligibleIndicator")]
        public string FNMNeighborsMortgageEligibleIndicator { get; set; }

        [XmlAttribute(AttributeName = "FNMCommunitySecondsIndicator")]
        public string FNMCommunitySecondsIndicator { get; set; }

        [XmlAttribute(AttributeName = "NonOccupantBorrowerCaseIndicator")]
        public string NonOccupantBorrowerCaseIndicator { get; set; }

        [XmlAttribute(AttributeName = "FlexClassification")]
        public int FlexClassification { get; set; }
    }

    [XmlRoot(ElementName = "NoteRate")]
    public class NoteRate
    {

        [XmlAttribute(AttributeName = "InterestRatePercent")]
        public double InterestRatePercent { get; set; }

        [XmlAttribute(AttributeName = "FirstMortgagePrincipalAndInterestAmount")]
        public double FirstMortgagePrincipalAndInterestAmount { get; set; }

        [XmlAttribute(AttributeName = "TotalExpensePaymentAmount")]
        public double TotalExpensePaymentAmount { get; set; }

        [XmlAttribute(AttributeName = "TotalProposedHousingPaymentAmount")]
        public double TotalProposedHousingPaymentAmount { get; set; }
    }

    [XmlRoot(ElementName = "QualifyingRate")]
    public class QualifyingRate
    {

        [XmlAttribute(AttributeName = "InterestRatePercent")]
        public double InterestRatePercent { get; set; }

        [XmlAttribute(AttributeName = "FirstMortgagePrincipalAndInterestAmount")]
        public double FirstMortgagePrincipalAndInterestAmount { get; set; }

        [XmlAttribute(AttributeName = "TotalExpensePaymentAmount")]
        public double TotalExpensePaymentAmount { get; set; }

        [XmlAttribute(AttributeName = "TotalProposedHousingPaymentAmount")]
        public double TotalProposedHousingPaymentAmount { get; set; }
    }

    [XmlRoot(ElementName = "Expense")]
    public class Expense
    {

        [XmlElement(ElementName = "NoteRate")]
        public NoteRate NoteRate { get; set; }

        [XmlElement(ElementName = "QualifyingRate")]
        public QualifyingRate QualifyingRate { get; set; }

        [XmlAttribute(AttributeName = "TotalPresentHousingPaymentAmount")]
        public double TotalPresentHousingPaymentAmount { get; set; }

        [XmlAttribute(AttributeName = "OtherFinancingPrincipalAndInterestAmount")]
        public double OtherFinancingPrincipalAndInterestAmount { get; set; }

        [XmlAttribute(AttributeName = "HazardInsuranceAmount")]
        public double HazardInsuranceAmount { get; set; }

        [XmlAttribute(AttributeName = "RealEstateTaxAmount")]
        public double RealEstateTaxAmount { get; set; }

        [XmlAttribute(AttributeName = "MIMonthlyAmount")]
        public double MIMonthlyAmount { get; set; }

        [XmlAttribute(AttributeName = "HomeownersAssociationDuesAndCondominiumFeesAmount")]
        public double HomeownersAssociationDuesAndCondominiumFeesAmount { get; set; }

        [XmlAttribute(AttributeName = "OtherHousingPaymentAmount")]
        public double OtherHousingPaymentAmount { get; set; }

        [XmlAttribute(AttributeName = "TotalOtherExpenseAmount")]
        public double TotalOtherExpenseAmount { get; set; }
    }

    [XmlRoot(ElementName = "Income")]
    public class Income
    {

        [XmlAttribute(AttributeName = "BaseIncomeAmount")]
        public double BaseIncomeAmount { get; set; }

        [XmlAttribute(AttributeName = "CommissionIncomeAmount")]
        public double CommissionIncomeAmount { get; set; }

        [XmlAttribute(AttributeName = "BonusIncomeAmount")]
        public double BonusIncomeAmount { get; set; }

        [XmlAttribute(AttributeName = "OvertimeIncomeAmount")]
        public double OvertimeIncomeAmount { get; set; }

        [XmlAttribute(AttributeName = "OtherIncomeAmount")]
        public double OtherIncomeAmount { get; set; }

        [XmlAttribute(AttributeName = "PositiveNetRentalIncomeAmount")]
        public double PositiveNetRentalIncomeAmount { get; set; }

        [XmlAttribute(AttributeName = "PositiveSubjectPropertyNetCashFlowAmount")]
        public double PositiveSubjectPropertyNetCashFlowAmount { get; set; }

        [XmlAttribute(AttributeName = "TotalIncomeAmount")]
        public double TotalIncomeAmount { get; set; }
    }

    [XmlRoot(ElementName = "IncomeAndExpense")]
    public class IncomeAndExpense
    {

        [XmlElement(ElementName = "Expense")]
        public Expense Expense { get; set; }

        [XmlElement(ElementName = "Income")]
        public Income Income { get; set; }
    }

    [XmlRoot(ElementName = "Borrower")]
    public class XmlBorrower
    {

        [XmlAttribute(AttributeName = "BorrowerTypeCode")]
        public int BorrowerTypeCode { get; set; }

        [XmlAttribute(AttributeName = "BorrowerFirstName")]
        public string BorrowerFirstName { get; set; }

        [XmlAttribute(AttributeName = "BorrowerMiddleName")]
        public object BorrowerMiddleName { get; set; }

        [XmlAttribute(AttributeName = "BorrowerLastName")]
        public string BorrowerLastName { get; set; }

        [XmlAttribute(AttributeName = "_NameSuffix")]
        public object NameSuffix { get; set; }

        [XmlAttribute(AttributeName = "_SSN")]
        public int SSN { get; set; }

        [XmlAttribute(AttributeName = "NonOccupantBorrowerIndicator")]
        public string NonOccupantBorrowerIndicator { get; set; }

        [XmlAttribute(AttributeName = "CitizenshipResidencyType")]
        public int CitizenshipResidencyType { get; set; }
    }

    [XmlRoot(ElementName = "Borrowers")]
    public class Borrowers
    {

        [XmlElement(ElementName = "Borrower")]
        public List<XmlBorrower> Borrower { get; set; }
    }

    [XmlRoot(ElementName = "GeoCodeOutput")]
    public class GeoCodeOutput
    {

        [XmlAttribute(AttributeName = "ScrubbedPropertyCity")]
        public string ScrubbedPropertyCity { get; set; }

        [XmlAttribute(AttributeName = "ScrubbedPropertyState")]
        public string ScrubbedPropertyState { get; set; }

        [XmlAttribute(AttributeName = "ScrubbedPropertyStreetAddress")]
        public object ScrubbedPropertyStreetAddress { get; set; }

        [XmlAttribute(AttributeName = "ScrubbedPropertyPostalCode")]
        public int ScrubbedPropertyPostalCode { get; set; }

        [XmlAttribute(AttributeName = "ScrubbedPropertyPostalCodeExtension")]
        public int ScrubbedPropertyPostalCodeExtension { get; set; }

        [XmlAttribute(AttributeName = "CensusTract")]
        public double CensusTract { get; set; }

        [XmlAttribute(AttributeName = "CountyName")]
        public string CountyName { get; set; }

        [XmlAttribute(AttributeName = "CountyCode")]
        public int CountyCode { get; set; }

        [XmlAttribute(AttributeName = "MSAIdentifier")]
        public string MSAIdentifier { get; set; }

        [XmlAttribute(AttributeName = "StateFIPSCode")]
        public int StateFIPSCode { get; set; }
    }

    [XmlRoot(ElementName = "Location")]
    public class Location
    {

        [XmlElement(ElementName = "GeoCodeOutput")]
        public GeoCodeOutput GeoCodeOutput { get; set; }

        [XmlAttribute(AttributeName = "PropertyCity")]
        public string PropertyCity { get; set; }

        [XmlAttribute(AttributeName = "PropertyState")]
        public string PropertyState { get; set; }

        [XmlAttribute(AttributeName = "PropertyStreetAddress")]
        public string PropertyStreetAddress { get; set; }

        [XmlAttribute(AttributeName = "PropertyPostalCode")]
        public int PropertyPostalCode { get; set; }

        [XmlAttribute(AttributeName = "PropertyPostalCodeExtension")]
        public object PropertyPostalCodeExtension { get; set; }
    }

    [XmlRoot(ElementName = "Property")]
    public class SubjectProperty
    {

        [XmlElement(ElementName = "Location")]
        public Location Location { get; set; }

        [XmlAttribute(AttributeName = "PropertyEstimatedValueAmount")]
        public double PropertyEstimatedValueAmount { get; set; }

        [XmlAttribute(AttributeName = "PropertyFinancedNumberOfUnits")]
        public int PropertyFinancedNumberOfUnits { get; set; }

        [XmlAttribute(AttributeName = "PropertyUsageTypeCode")]
        public int PropertyUsageTypeCode { get; set; }

        [XmlAttribute(AttributeName = "GSEPropertyTypeCode")]
        public int GSEPropertyTypeCode { get; set; }

        [XmlAttribute(AttributeName = "GSEProjectClassificationTypeCode")]
        public int GSEProjectClassificationTypeCode { get; set; }
    }

    [XmlRoot(ElementName = "UnderwritingAnalysis")]
    public class UnderwritingAnalysis
    {

        [XmlAttribute(AttributeName = "RequiredFundsAmount")]
        public double RequiredFundsAmount { get; set; }

        [XmlAttribute(AttributeName = "AvailableFundsAmount")]
        public double AvailableFundsAmount { get; set; }

        [XmlAttribute(AttributeName = "CashBackAmount")]
        public double CashBackAmount { get; set; }

        [XmlAttribute(AttributeName = "ShortageAmount")]
        public double ShortageAmount { get; set; }

        [XmlAttribute(AttributeName = "NetCashBackAmount")]
        public double NetCashBackAmount { get; set; }

        [XmlAttribute(AttributeName = "ReservesAmount")]
        public double ReservesAmount { get; set; }

        [XmlAttribute(AttributeName = "ReserveMonths")]
        public int ReserveMonths { get; set; }

        [XmlAttribute(AttributeName = "HousingExpenseRatioPercent")]
        public DateTime HousingExpenseRatioPercent { get; set; }

        [XmlAttribute(AttributeName = "TotalExpenseRatioPercent")]
        public double TotalExpenseRatioPercent { get; set; }

        [XmlAttribute(AttributeName = "TotalExpenseRatioWithLessThanOrEqualTo10MonthsPercent")]
        public double TotalExpenseRatioWithLessThanOrEqualTo10MonthsPercent { get; set; }

        [XmlAttribute(AttributeName = "TotalExpenseRatioWithUndisclosedLiabilitiesPercent")]
        public double TotalExpenseRatioWithUndisclosedLiabilitiesPercent { get; set; }

        [XmlAttribute(AttributeName = "PaymentFrequencyTypeCode")]
        public int PaymentFrequencyTypeCode { get; set; }

        [XmlAttribute(AttributeName = "AssetsToVerifyAmount")]
        public double AssetsToVerifyAmount { get; set; }

        [XmlAttribute(AttributeName = "PercentSellerContribution")]
        public double PercentSellerContribution { get; set; }

        [XmlAttribute(AttributeName = "SellerContributionAmount")]
        public double SellerContributionAmount { get; set; }

        [XmlAttribute(AttributeName = "BorrowerFundsAsPctSalesPrc")]
        public int BorrowerFundsAsPctSalesPrc { get; set; }

        [XmlAttribute(AttributeName = "EstBorrowerContributionAmount")]
        public double EstBorrowerContributionAmount { get; set; }

        [XmlAttribute(AttributeName = "EstBorrowerContributionPercent")]
        public double EstBorrowerContributionPercent { get; set; }
    }

    [XmlRoot(ElementName = "SpecialFeatureCode")]
    public class SpecialFeatureCode
    {

        [XmlAttribute(AttributeName = "SpecialFeatureCode")]
        public int SpecialFeatCode { get; set; }

        [XmlAttribute(AttributeName = "SpecialFeatureDescription")]
        public string SpecialFeatureDescription { get; set; }
    }

    [XmlRoot(ElementName = "SpecialFeatureCodes")]
    public class SpecialFeatureCodes
    {

        [XmlElement(ElementName = "SpecialFeatureCode")]
        public SpecialFeatureCode SpecialFeatureCode { get; set; }
    }

    [XmlRoot(ElementName = "ListAsset")]
    public class ListAsset
    {

        [XmlAttribute(AttributeName = "BorrowerUnparsedName")]
        public string BorrowerUnparsedName { get; set; }

        [XmlAttribute(AttributeName = "_SSN")]
        public int SSN { get; set; }

        [XmlAttribute(AttributeName = "AssetTypeCode")]
        public int AssetTypeCode { get; set; }

        [XmlAttribute(AttributeName = "CashOrMarketValueAmount")]
        public double CashOrMarketValueAmount { get; set; }

        [XmlAttribute(AttributeName = "AssetInstitution")]
        public string AssetInstitution { get; set; }
    }

    [XmlRoot(ElementName = "ListIncome")]
    public class ListIncome
    {

        [XmlAttribute(AttributeName = "BorrowerUnparsedName")]
        public string BorrowerUnparsedName { get; set; }

        [XmlAttribute(AttributeName = "_SSN")]
        public int SSN { get; set; }

        [XmlAttribute(AttributeName = "IncomeTypeCode")]
        public string IncomeTypeCode { get; set; }

        [XmlAttribute(AttributeName = "IncomeAmount")]
        public double IncomeAmount { get; set; }
    }

    [XmlRoot(ElementName = "IncomeAssetEmploymentList")]
    public class IncomeAssetEmploymentList
    {

        [XmlElement(ElementName = "ListAsset")]
        public ListAsset ListAsset { get; set; }

        [XmlElement(ElementName = "ListIncome")]
        public ListIncome ListIncome { get; set; }
    }

    [XmlRoot(ElementName = "CreditRiskScore")]
    public class CreditRiskScore
    {

        [XmlAttribute(AttributeName = "ScoringModelName")]
        public string ScoringModelName { get; set; }

        [XmlAttribute(AttributeName = "ScoringSource")]
        public int ScoringSource { get; set; }

        [XmlAttribute(AttributeName = "ScoreValue")]
        public int ScoreValue { get; set; }
    }

    [XmlRoot(ElementName = "CreditReportBorrowerInformation")]
    public class CreditReportBorrowerInformation
    {

        [XmlElement(ElementName = "CreditRiskScore")]
        public List<CreditRiskScore> CreditRiskScore { get; set; }

        [XmlAttribute(AttributeName = "SubjectSpouseCode")]
        public int SubjectSpouseCode { get; set; }

        [XmlAttribute(AttributeName = "_SSN")]
        public int SSN { get; set; }
    }

    [XmlRoot(ElementName = "CreditReport")]
    public class CreditReport
    {

        [XmlElement(ElementName = "CreditReportBorrowerInformation")]
        public List<CreditReportBorrowerInformation> CreditReportBorrowerInformation { get; set; }

        [XmlAttribute(AttributeName = "AgencyReferenceNumber")]
        public string AgencyReferenceNumber { get; set; }

        [XmlAttribute(AttributeName = "JointIndividualIndicator")]
        public string JointIndividualIndicator { get; set; }

        [XmlAttribute(AttributeName = "AgencyIdentifier")]
        public int AgencyIdentifier { get; set; }

        [XmlAttribute(AttributeName = "AgencyName")]
        public string AgencyName { get; set; }

        [XmlAttribute(AttributeName = "_Date")]
        public int Date { get; set; }
    }

    [XmlRoot(ElementName = "TradelinesSummary")]
    public class TradelinesSummary
    {

        [XmlAttribute(AttributeName = "Count")]
        public int Count { get; set; }

        [XmlAttribute(AttributeName = "NumberOfMortgages")]
        public int NumberOfMortgages { get; set; }

        [XmlAttribute(AttributeName = "NumberOpen")]
        public int NumberOpen { get; set; }

        [XmlAttribute(AttributeName = "NumberOpenRevolving")]
        public object NumberOpenRevolving { get; set; }

        [XmlAttribute(AttributeName = "NumberOpenSixMoreMonthsOld")]
        public object NumberOpenSixMoreMonthsOld { get; set; }

        [XmlAttribute(AttributeName = "NumberOpenedPast6Months")]
        public int NumberOpenedPast6Months { get; set; }

        [XmlAttribute(AttributeName = "NumberOpenedPast7to12Months")]
        public int NumberOpenedPast7to12Months { get; set; }

        [XmlAttribute(AttributeName = "AverageAge")]
        public int AverageAge { get; set; }

        [XmlAttribute(AttributeName = "RevolvingBalance")]
        public object RevolvingBalance { get; set; }

        [XmlAttribute(AttributeName = "RevolvingLimit")]
        public object RevolvingLimit { get; set; }
    }

    [XmlRoot(ElementName = "DelinquentTradelinesSummary")]
    public class DelinquentTradelinesSummary
    {

        [XmlAttribute(AttributeName = "NumberEver30Plus")]
        public int NumberEver30Plus { get; set; }

        [XmlAttribute(AttributeName = "NumberEver60Plus")]
        public int NumberEver60Plus { get; set; }

        [XmlAttribute(AttributeName = "NumberMortgageEver30Plus")]
        public int NumberMortgageEver30Plus { get; set; }

        [XmlAttribute(AttributeName = "NumberMortgageEver60Plus")]
        public int NumberMortgageEver60Plus { get; set; }

        [XmlAttribute(AttributeName = "NumberCurrentPastDue")]
        public int NumberCurrentPastDue { get; set; }

        [XmlAttribute(AttributeName = "DelinquencyPercent")]
        public double DelinquencyPercent { get; set; }
    }

    [XmlRoot(ElementName = "DelinquenciesSummary")]
    public class DelinquenciesSummary
    {

        [XmlAttribute(AttributeName = "Number30PlusPast12Month")]
        public object Number30PlusPast12Month { get; set; }

        [XmlAttribute(AttributeName = "NumberTradelineBankruptcies")]
        public int NumberTradelineBankruptcies { get; set; }

        [XmlAttribute(AttributeName = "NumberTradelineForeclosures")]
        public int NumberTradelineForeclosures { get; set; }
    }

    [XmlRoot(ElementName = "MajorDerogatoryCreditDetail")]
    public class MajorDerogatoryCreditDetail
    {

        [XmlAttribute(AttributeName = "Type")]
        public int Type { get; set; }

        [XmlAttribute(AttributeName = "Count")]
        public int Count { get; set; }
    }

    [XmlRoot(ElementName = "MajorDerogatoryCredit")]
    public class MajorDerogatoryCredit
    {

        [XmlElement(ElementName = "MajorDerogatoryCreditDetail")]
        public List<MajorDerogatoryCreditDetail> MajorDerogatoryCreditDetail { get; set; }
    }

    [XmlRoot(ElementName = "CreditReportSummary")]
    public class CreditReportSummary
    {

        [XmlElement(ElementName = "CreditReport")]
        public CreditReport CreditReport { get; set; }

        [XmlElement(ElementName = "TradelinesSummary")]
        public TradelinesSummary TradelinesSummary { get; set; }

        [XmlElement(ElementName = "DelinquentTradelinesSummary")]
        public DelinquentTradelinesSummary DelinquentTradelinesSummary { get; set; }

        [XmlElement(ElementName = "DelinquenciesSummary")]
        public DelinquenciesSummary DelinquenciesSummary { get; set; }

        [XmlElement(ElementName = "MajorDerogatoryCredit")]
        public MajorDerogatoryCredit MajorDerogatoryCredit { get; set; }

        [XmlAttribute(AttributeName = "NumberOfBorrowersWithCredit")]
        public int NumberOfBorrowersWithCredit { get; set; }

        [XmlAttribute(AttributeName = "MostRecentCreditReportDate")]
        public int MostRecentCreditReportDate { get; set; }
    }

    [XmlRoot(ElementName = "EndNote")]
    public class EndNote
    {

        [XmlAttribute(AttributeName = "Text")]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "CodifiedFindings")]
    public class CodifiedFindings
    {

        [XmlElement(ElementName = "ResponseHeader")]
        public ResponseHeader ResponseHeader { get; set; }

        [XmlElement(ElementName = "Casefile")]
        public Casefile Casefile { get; set; }

        [XmlElement(ElementName = "CasefileMessages")]
        public CasefileMessages CasefileMessages { get; set; }

        [XmlElement(ElementName = "DocumentationLevelCodes")]
        public List<DocumentationLevelCodes> DocumentationLevelCodes { get; set; }

        [XmlElement(ElementName = "MICoverage")]
        public MICoverage MICoverage { get; set; }

        [XmlElement(ElementName = "RecommendationCode")]
        public RecommendationCode RecommendationCode { get; set; }

        [XmlElement(ElementName = "LoanDetails")]
        public LoanDetails LoanDetails { get; set; }

        [XmlElement(ElementName = "IncomeAndExpense")]
        public IncomeAndExpense IncomeAndExpense { get; set; }

        [XmlElement(ElementName = "Borrowers")]
        public Borrowers Borrowers { get; set; }

        [XmlElement(ElementName = "Property")]
        public SubjectProperty Property { get; set; }

        [XmlElement(ElementName = "UnderwritingAnalysis")]
        public UnderwritingAnalysis UnderwritingAnalysis { get; set; }

        [XmlElement(ElementName = "SpecialFeatureCodes")]
        public SpecialFeatureCodes SpecialFeatureCodes { get; set; }

        [XmlElement(ElementName = "IncomeAssetEmploymentList")]
        public IncomeAssetEmploymentList IncomeAssetEmploymentList { get; set; }

        [XmlElement(ElementName = "CreditReportSummary")]
        public CreditReportSummary CreditReportSummary { get; set; }

        [XmlElement(ElementName = "EndNote")]
        public EndNote EndNote { get; set; }
    }


}
